using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Domain.RepositoryDapper.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);
        Task<int> BulkInsertAsync(IEnumerable<T> entities);
        Task<IEnumerable<T>> BulkLoadAsync(string procedure, object parameters = null);
        Task<IEnumerable<T>> GetPaginatedAsync(int pageIndex, int pageSize, string filter);
    }

}
