using Microsoft.EntityFrameworkCore;
using NewCI.Entities;
using NewCI.Entities.Data;
using NewCI.Entities.Models;
using NewCI.Interfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NewCI.Repositories
{
    public class GenericRepository<T> : IGenericInterface<T> where T : class
    {
        public readonly DatabasewithDataContext _db;
        public GenericRepository(DatabasewithDataContext db)
        {
            _db = db;
        }
        public bool Add(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
            return true;
        }
        public bool Delete(long id)
        {
            var entity = _db.Set<T>().Find(id);
            if (entity != null)
            {
                if (typeof(T).GetProperty("DeletedAt") != null)
                {
                    typeof(T).GetProperty("DeletedAt")!.SetValue(entity, DateTime.Now);
                }
                else
                {
                    _db.Set<T>().Remove(entity);
                }
                _db.SaveChanges();
                return true;
            }
            return false;
        }
        //List<T> entries = await query.ToListAsync();
        public async Task<IEnumerable<T>> GetAllRecordsAsync()
        {
            IQueryable<T> query = _db.Set<T>();
            var deletedAtProperty = typeof(T).GetProperty("DeletedAt");
            if (deletedAtProperty != null && deletedAtProperty.PropertyType == typeof(DateTime?))
            {
                var nullValue = (DateTime?)null;
                query = query.Where(x => EF.Property<DateTime?>(x, "DeletedAt") == nullValue);
            }
            return await query.ToListAsync();
        }
        public PagedResult<T> GetAll(int pageNumber,string? sortBy, int pageSize = 5,string? search=null,string? searchOnProperty=null)
        {
            IQueryable<T> query = _db.Set<T>();
            var deletedAtProperty = typeof(T).GetProperty("DeletedAt");
            if (deletedAtProperty != null && deletedAtProperty.PropertyType == typeof(DateTime?))
            {
                query = query.AsEnumerable().Where(x => deletedAtProperty.GetValue(x) == null).AsQueryable();
            }

            if (!string.IsNullOrEmpty(search) && !string.IsNullOrEmpty(searchOnProperty))
            {
                var property = typeof(T).GetProperty(searchOnProperty);
                if (property != null && property.PropertyType == typeof(string))
                {
                    query = query.Where(x => ((string)property.GetValue(x)!).Contains(search, StringComparison.OrdinalIgnoreCase) == true);
                }
            }
            query = ApplySorting(query, sortBy);
       
            return new PagedResult<T>
            {
                Entries = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(),
                TotalPages = (int)Math.Ceiling((double)(query.Count()) / pageSize)
            };
        }
        public T? GetById(long id)
        {
            return _db.Set<T>().Find(id);
        }
        public bool Update(T entity)
        {
            _db.Set<T>().Update(entity);
            _db.SaveChanges();
            return true;
        }
        private IQueryable<T> ApplySorting(IQueryable<T> query, string? sortBy)
        {
            if (!string.IsNullOrEmpty(sortBy))
            {
                var property = typeof(T).GetProperty(sortBy);
                if (property != null)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        return query.OrderBy(x => (string)property.GetValue(x)!);
                    }
                    else
                    {
                        return query.OrderBy(x => property.GetValue(x));
                    }
                }
            }

            return query;
        }

    }
}
