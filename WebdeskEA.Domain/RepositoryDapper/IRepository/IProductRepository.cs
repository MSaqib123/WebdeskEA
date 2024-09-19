using WebdeskEA.Models.DbModel;
using WebdeskEA.Models.MappingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Domain.RepositoryDapper.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<int> AddProductAsync(ProductDto productDto);
        Task<int> UpdateProductAsync(ProductDto productDto);
        Task<int> DeleteProductAsync(int id);
        Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId);
        Task<int> BulkInsertProductsAsync(IEnumerable<ProductDto> productDtos);
        Task<IEnumerable<ProductDto>> BulkLoadProductsAsync(string procedure, object parameters = null);
        Task<IEnumerable<ProductDto>> GetPaginatedProductsAsync(int pageIndex, int pageSize, string filter);
    }

}
