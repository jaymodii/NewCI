using NewCI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCI.Interfaces.ServiceInterfaces
{
    public interface IGenericService<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllRecordsAsync();
        public bool Add(T entity);
        public bool Delete(long id);
        public PagedResult<T> GetAll(int pageNumber, string sortBy, int pageSize = 5);
        public bool Update(T entity);
        public T? GetByID(long id);
    }

}
