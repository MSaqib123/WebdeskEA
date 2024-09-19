using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebdeskEA.Domain.RepositoryDapper.IRepository;
using WebdeskEA.Domain.RepositoryEntity.IRepository;
using WebdeskEA.Domain.Service;
using WebdeskEA.Models.MappingModel;
using WebdeskEA.Utility;
using WebdeskEA.Utility.EnumUtality;

namespace CRM.Areas.CompanySites.Controllers
{
    [Area("CompanySites")]
    [Authorize]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IErrorLogRepository _errorLogRepository;

        public CompanyController(ICompanyRepository companyRepository, IErrorLogRepository errorLogRepository)
        {
            _companyRepository = companyRepository;
            _errorLogRepository = errorLogRepository ?? throw new ArgumentNullException(nameof(errorLogRepository));
        }

        // GET: /Company/Index
        public async Task<IActionResult> Index()
        {
            try
            {
                //int divisor = 0;
                //int result = 1 / divisor; // This will cause a DivideByZeroException
                var companies = await _companyRepository.GetAllCompaniesAsync();
                return View(companies);
            }
            catch (Exception ex)
            {
                var (errorCode, statusCode) = ErrorUtility.GenerateErrorCodeAndStatus(ex);
                // Log the error
                await _errorLogRepository.AddErrorLogAsync(
                    area: "CompanySites",
                    controller: "Company",
                    actionName: "Index",
                    formName: "CompanyList Form",
                    errorShortDescription: ex.Message,
                    errorLongDescription: ErrorUtility.GetFullExceptionMessage(ex),
                    statusCode: statusCode.ToString(),
                    username: User.Identity?.Name
                );
                return RedirectToAction("Error", "Error", new { area = "Settings", statusCode = statusCode, errorMessage =ex.Message});
            }
        }

        // GET: /Company/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var company = await _companyRepository.GetCompanyByIdAsync(id);
                if (company == null)
                {
                    return NotFound();
                }
                return View(company);
            }
            catch (Exception ex)
            {
                var (errorCode, statusCode) = ErrorUtility.GenerateErrorCodeAndStatus(ex);
                // Log the error
                await _errorLogRepository.AddErrorLogAsync(
                    area: "CompanySites",
                    controller: "Company",
                    actionName: "DetailsAction",
                    formName: "DetailCompanyForm",
                    errorShortDescription: ex.Message,
                    errorLongDescription: ErrorUtility.GetFullExceptionMessage(ex),
                    statusCode: statusCode.ToString(),
                    username: User.Identity?.Name
                );
                
                return RedirectToAction("Error", "Error", new { area = "Settings", statusCode = statusCode, errorMessage = ex.Message });
            }
            
        }

        // GET: /Company/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyDto companyDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newCompanyId = await _companyRepository.AddCompanyAsync(companyDto);
                    return RedirectToAction(nameof(Details), new { id = newCompanyId });
                }
                return View(companyDto);
            }
            catch (Exception ex)
            {
                var (errorCode, statusCode) = ErrorUtility.GenerateErrorCodeAndStatus(ex);
                // Log the error
                await _errorLogRepository.AddErrorLogAsync(
                    area: "CompanySites",
                    controller: "Company",
                    actionName: "CreatePost",
                    formName: "Create Form",
                    errorShortDescription: ex.Message,
                    errorLongDescription: ErrorUtility.GetFullExceptionMessage(ex),
                    statusCode: statusCode.ToString(),
                    username: User.Identity?.Name
                );

                return RedirectToAction("Error", "Error", new { area = "Settings", statusCode = statusCode, errorMessage = ex.Message });
            }
        }

        // GET: /Company/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var company = await _companyRepository.GetCompanyByIdAsync(id);
                if (company == null)
                {
                    return NotFound();
                }
                return View(company);
            }
            catch (Exception ex)
            {
                var (errorCode, statusCode) = ErrorUtility.GenerateErrorCodeAndStatus(ex);
                // Log the error
                await _errorLogRepository.AddErrorLogAsync(
                    area: "CompanySites",
                    controller: "Company",
                    actionName: "EditGet",
                    formName: "UpdateView Form",
                    errorShortDescription: ex.Message,
                    errorLongDescription: ErrorUtility.GetFullExceptionMessage(ex),
                    statusCode: statusCode.ToString(),
                    username: User.Identity?.Name
                );

                return RedirectToAction("Error", "Error", new { area = "Settings", statusCode = statusCode, errorMessage = ex.Message });
            }
        }

        // POST: /Company/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompanyDto companyDto)
        {
            try { 
                if (id != companyDto.Id)
                {
                    return BadRequest("Company ID mismatch");
                }

                if (ModelState.IsValid)
                {
                    var result = await _companyRepository.UpdateCompanyAsync(companyDto);
                    if (result == 0)
                    {
                        return NotFound();
                    }
                    return RedirectToAction(nameof(Details), new { id = companyDto.Id });
                }
                return View(companyDto);
            }
            catch (Exception ex)
            {
                var (errorCode, statusCode) = ErrorUtility.GenerateErrorCodeAndStatus(ex);
                // Log the error
                await _errorLogRepository.AddErrorLogAsync(
                    area: "CompanySites",
                    controller: "Company",
                    actionName: "EditPost",
                    formName: "Update Submited Form",
                    errorShortDescription: ex.Message,
                    errorLongDescription: ErrorUtility.GetFullExceptionMessage(ex),
                    statusCode: statusCode.ToString(),
                    username: User.Identity?.Name
                );

                return RedirectToAction("Error", "Error", new { area = "Settings", statusCode = statusCode, errorMessage = ex.Message });
            }
        }

        // GET: /Company/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: /Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _companyRepository.DeleteCompanyAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: /Company/Search?name={name}
        public async Task<IActionResult> Search(string name)
        {
            var companies = await _companyRepository.GetCompaniesByNameAsync(name);
            return View("Index", companies);  // Reuse the Index view to display the search results
        }

        // GET: /Company/Paginated?pageIndex={pageIndex}&pageSize={pageSize}&filter={filter}
        public async Task<IActionResult> Paginated(int pageIndex, int pageSize, string filter)
        {
            var companies = await _companyRepository.GetPaginatedCompaniesAsync(pageIndex, pageSize, filter);
            return View("Index", companies);  // Reuse the Index view to display paginated results
        }
    }
}
