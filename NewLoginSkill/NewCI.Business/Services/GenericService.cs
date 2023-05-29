using NewCI.Entities;
using NewCI.Interfaces.RepositoryInterfaces;
using NewCI.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCI.Business.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericInterface<T> _repo;

        public GenericService(IGenericInterface<T> repository)
        {
            _repo = repository;
        }

        public async Task<IEnumerable<T>> GetAllRecordsAsync()
        {
            return await _repo.GetAllRecordsAsync();
        }
        public bool Add(T entity)
        {
            
            return _repo.Add(entity);
        }

        public bool Delete(long id)
        {
            
            return _repo.Delete(id);

        }

        public PagedResult<T> GetAll(int pageNumber,string sortBy,int pageSize=5,string? search=null,string? searchOnProperty=null)
        {
            return _repo.GetAll(pageNumber,sortBy,pageSize,search,searchOnProperty);
        }

        public bool Update(T entity)
        {

            return _repo.Update(entity);

        }
        public T? GetByID(long id)
        {
            return _repo.GetById(id);
        }

    }

}
