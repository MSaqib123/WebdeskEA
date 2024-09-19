using WebdeskEA.DataAccess.DapperFactory;
using WebdeskEA.Domain.RepositoryDapper.IRepository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Domain.RepositoryDapper
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IDbConnection _dbConnection;

        public Repository(IDapperDbConnectionFactory dbConnectionFactory)
        {
            _dbConnection = dbConnectionFactory.CreateConnection();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            var procedure = $"{typeof(T).Name}_GetById";
            var parameters = new { Id = id };
            return await _dbConnection.QueryFirstOrDefaultAsync<T>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var procedure = $"{typeof(T).Name}_GetAll";
            return await _dbConnection.QueryAsync<T>(procedure, commandType: CommandType.StoredProcedure);
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            var procedure = $"{typeof(T).Name}_Insert";
            return await _dbConnection.ExecuteAsync(procedure, entity, commandType: CommandType.StoredProcedure);
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            var procedure = $"{typeof(T).Name}_Update";
            return await _dbConnection.ExecuteAsync(procedure, entity, commandType: CommandType.StoredProcedure);
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            var procedure = $"{typeof(T).Name}_Delete";
            var parameters = new { Id = id };
            return await _dbConnection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public virtual async Task<int> BulkInsertAsync(IEnumerable<T> entities)
        {
            var procedure = $"{typeof(T).Name}_BulkInsert";
            return await _dbConnection.ExecuteAsync(procedure, new { Items = entities }, commandType: CommandType.StoredProcedure);
        }

        public virtual async Task<IEnumerable<T>> BulkLoadAsync(string procedure, object parameters = null)
        {
            return await _dbConnection.QueryAsync<T>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public virtual async Task<IEnumerable<T>> GetPaginatedAsync(int pageIndex, int pageSize, string filter)
        {
            var procedure = $"{typeof(T).Name}_GetPaginated";
            var parameters = new { PageIndex = pageIndex, PageSize = pageSize, Filter = filter };
            return await _dbConnection.QueryAsync<T>(procedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }

}
