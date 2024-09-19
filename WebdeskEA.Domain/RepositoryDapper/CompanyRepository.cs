using AutoMapper;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebdeskEA.DataAccess.DapperFactory;
using WebdeskEA.Models.DbModel;
using WebdeskEA.Models.MappingModel;
using WebdeskEA.Domain.RepositoryDapper.IRepository;
using WebdeskEA.Models.ExternalModel;

namespace WebdeskEA.Domain.RepositoryDapper
{

    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly IMapper _mapper;

        public CompanyRepository(IDapperDbConnectionFactory dbConnectionFactory, IMapper mapper)
            : base(dbConnectionFactory)
        {
            _mapper = mapper;
        }

        // Get company by Id
        public async Task<CompanyDto> GetCompanyByIdAsync(int id)
        {
            var procedure = "spCompany_GetById";
            var parameters = new { Id = id };
            var company = await _dbConnection.QueryFirstOrDefaultAsync<Company>(procedure, parameters, commandType: CommandType.StoredProcedure);
            return _mapper.Map<CompanyDto>(company);
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync()
        {
            var procedure = "spCompany_GetAll";
            var companies = await _dbConnection.QueryAsync<Company>(procedure, commandType: CommandType.StoredProcedure);
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        // Add a new company
        public async Task<int> AddCompanyAsync(CompanyDto companyDto)
        {
            var procedure = "spCompany_Insert";
            var company = _mapper.Map<Company>(companyDto);
            return await _dbConnection.ExecuteAsync(procedure, company, commandType: CommandType.StoredProcedure);
        }

        // Update an existing company
        public async Task<int> UpdateCompanyAsync(CompanyDto companyDto)
        {
            var procedure = "spCompany_Update";
            var company = _mapper.Map<Company>(companyDto);
            return await _dbConnection.ExecuteAsync(procedure, company, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ApplicationUserDto>> GetAllUsersNEICUWithUpdateAsync()
        {
            var procedure = "spGetAllUserNotExistInCompanyUserWithUpdate";
            var companies = await _dbConnection.QueryAsync<ApplicationUser>(procedure, commandType: CommandType.StoredProcedure);
            return _mapper.Map<IEnumerable<ApplicationUserDto>>(companies);
        }

        // Delete a company by Id
        public async Task<int> DeleteCompanyAsync(int id)
        {
            var procedure = "spCompany_Delete";
            var parameters = new { Id = id };
            return await _dbConnection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
        }

        // Get companies by name filter
        public async Task<IEnumerable<CompanyDto>> GetCompaniesByNameAsync(string name)
        {
            var procedure = "spCompany_GetByName";
            var parameters = new { Name = name };
            var companies = await _dbConnection.QueryAsync<Company>(procedure, parameters, commandType: CommandType.StoredProcedure);
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        // Bulk insert companies
        public async Task<int> BulkInsertCompaniesAsync(IEnumerable<CompanyDto> companyDtos)
        {
            var procedure = "spCompany_BulkInsert";
            var companies = _mapper.Map<IEnumerable<Company>>(companyDtos);
            return await _dbConnection.ExecuteAsync(procedure, new { Items = companies }, commandType: CommandType.StoredProcedure);
        }

        // Bulk load companies
        public async Task<IEnumerable<CompanyDto>> BulkLoadCompaniesAsync(string procedure, object parameters = null)
        {
            var companies = await _dbConnection.QueryAsync<Company>(procedure, parameters, commandType: CommandType.StoredProcedure);
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        // Get paginated companies
        public async Task<IEnumerable<CompanyDto>> GetPaginatedCompaniesAsync(int pageIndex, int pageSize, string filter)
        {
            var procedure = "Company_GetPaginated";
            var parameters = new { PageIndex = pageIndex, PageSize = pageSize, Filter = filter };
            var companies = await _dbConnection.QueryAsync<Company>(procedure, parameters, commandType: CommandType.StoredProcedure);
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }
    }

}
