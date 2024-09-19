using WebdeskEA.Models.MappingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Domain.RepositoryDapper.IRepository
{
    public interface ICompanyRepository
    {
        Task<CompanyDto> GetCompanyByIdAsync(int id);
        Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync();
        Task<int> AddCompanyAsync(CompanyDto companyDto);
        Task<int> UpdateCompanyAsync(CompanyDto companyDto);

        Task<int> DeleteCompanyAsync(int id);
        Task<IEnumerable<CompanyDto>> GetCompaniesByNameAsync(string name);
        Task<int> BulkInsertCompaniesAsync(IEnumerable<CompanyDto> companyDtos);
        Task<IEnumerable<CompanyDto>> BulkLoadCompaniesAsync(string procedure, object parameters = null);
        Task<IEnumerable<CompanyDto>> GetPaginatedCompaniesAsync(int pageIndex, int pageSize, string filter);
    }
}
