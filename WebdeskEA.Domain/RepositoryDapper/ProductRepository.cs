using WebdeskEA.DataAccess.DapperFactory;
using WebdeskEA.Domain.RepositoryDapper.IRepository;
using WebdeskEA.Models.DbModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Domain.RepositoryDapper
{
    using AutoMapper;
    using Dapper;
    using System.Data;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using WebdeskEA.Models.MappingModel;

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IMapper _mapper;

        public ProductRepository(IDapperDbConnectionFactory dbConnectionFactory, IMapper mapper)
            : base(dbConnectionFactory)
        {
            _mapper = mapper;
        }

        // Get product by Id
        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var procedure = "Product_GetById";
            var parameters = new { Id = id };
            var product = await _dbConnection.QueryFirstOrDefaultAsync<Product>(procedure, parameters, commandType: CommandType.StoredProcedure);
            return _mapper.Map<ProductDto>(product);
        }

        // Get all products
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var procedure = "Product_GetAll";
            var products = await _dbConnection.QueryAsync<Product>(procedure, commandType: CommandType.StoredProcedure);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        // Add a new product
        public async Task<int> AddProductAsync(ProductDto productDto)
        {
            var procedure = "Product_Insert";
            var product = _mapper.Map<Product>(productDto);
            return await _dbConnection.ExecuteAsync(procedure, product, commandType: CommandType.StoredProcedure);
        }

        // Update an existing product
        public async Task<int> UpdateProductAsync(ProductDto productDto)
        {
            var procedure = "Product_Update";
            var product = _mapper.Map<Product>(productDto);
            return await _dbConnection.ExecuteAsync(procedure, product, commandType: CommandType.StoredProcedure);
        }

        // Delete a product by Id
        public async Task<int> DeleteProductAsync(int id)
        {
            var procedure = "Product_Delete";
            var parameters = new { Id = id };
            return await _dbConnection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
        }

        // Get products by category
        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId)
        {
            var procedure = "GetProductsByCategory";
            var parameters = new { CategoryId = categoryId };
            var products = await _dbConnection.QueryAsync<Product>(procedure, parameters, commandType: CommandType.StoredProcedure);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        // Bulk insert products
        public async Task<int> BulkInsertProductsAsync(IEnumerable<ProductDto> productDtos)
        {
            var procedure = "Product_BulkInsert";
            var products = _mapper.Map<IEnumerable<Product>>(productDtos);
            return await _dbConnection.ExecuteAsync(procedure, new { Items = products }, commandType: CommandType.StoredProcedure);
        }

        // Bulk load products
        public async Task<IEnumerable<ProductDto>> BulkLoadProductsAsync(string procedure, object parameters = null)
        {
            var products = await _dbConnection.QueryAsync<Product>(procedure, parameters, commandType: CommandType.StoredProcedure);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        // Get paginated products
        public async Task<IEnumerable<ProductDto>> GetPaginatedProductsAsync(int pageIndex, int pageSize, string filter)
        {
            var procedure = "Product_GetPaginated";
            var parameters = new { PageIndex = pageIndex, PageSize = pageSize, Filter = filter };
            var products = await _dbConnection.QueryAsync<Product>(procedure, parameters, commandType: CommandType.StoredProcedure);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }


}
