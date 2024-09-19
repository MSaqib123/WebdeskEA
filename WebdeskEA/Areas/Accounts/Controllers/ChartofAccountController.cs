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
namespace CRM.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    [Authorize]
    public class ChartofAccountController : Controller
    {
        //=================== Constructor =====================
        #region Constructor
        private readonly ICOARepository _Coa;
        private readonly ICOATypeRepository _CoaType;
        private readonly IEnumService _enumService;
        private readonly ICompanyUserRepository _companyUserRepository;
        private readonly ICompanyRepository _CompanyRepository;
        private readonly ICompanyBusinessCategoryRepository _companyBusinessCategoryRepository;
        private readonly IErrorLogRepository _errorLogRepository;

        public ChartofAccountController(ICompanyUserRepository companyUserRepository,
            IErrorLogRepository errorLogRepository,
            ICompanyRepository companyRepository,
            ICompanyBusinessCategoryRepository companyBusinessCategoryRepository,
            ICOARepository Coa,
            ICOATypeRepository CoaType,
            IEnumService enumService
            )
        {
            _companyUserRepository = companyUserRepository;
            _enumService = enumService;
            _errorLogRepository = errorLogRepository ?? throw new ArgumentNullException(nameof(errorLogRepository));
            _CompanyRepository = companyRepository;
            _companyBusinessCategoryRepository = companyBusinessCategoryRepository;
            _Coa = Coa;
            _CoaType = CoaType;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.NameOfForm = "Chart of Account";
            base.OnActionExecuting(context);
        }

        #endregion

        //=================== Model_Binding =====================
        #region Model_Binding
        //----- Get -----
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _Coa.GetAllListAsync();
                return View(list);
            }
            catch (Exception ex)
            {
                await LogError(ex);
                return RedirectToAction("Error", "Error", new { area = "Settings", statusCode = 500, errorMessage = ex.Message });
            }
        }

        //----- Create -----
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            try
            {
                COADto Dto = new COADto();
                Dto.COADtoList = await _Coa.GetAllListAsync();
                Dto.BusinessCategoryList = await _companyBusinessCategoryRepository.GetAllCompanyBusinessCategoryAsync();
                Dto.CoatypeDtoList = await _CoaType.GetAllListAsync();
                Dto.CoaTransactionTypeList = new SelectList(_enumService.GetTransactionTypes(), "Key", "Value");

                return View(Dto);
            }
            catch (Exception ex)
            {
                await LogError(ex);
                return RedirectToAction("Error", "Error", new { area = "Accounts", statusCode = 500, errorMessage = ex.Message });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(COADto Dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newCompanyId = await _Coa.AddAsync(Dto);
                    return RedirectToAction(nameof(Details), new { id = newCompanyId });
                }
                else
                {
                    Dto.COADtoList = await _Coa.GetAllListAsync();
                    Dto.BusinessCategoryList = await _companyBusinessCategoryRepository.GetAllCompanyBusinessCategoryAsync();
                    Dto.CoatypeDtoList = await _CoaType.GetAllListAsync();
                    Dto.CoaTransactionTypeList = new SelectList(_enumService.GetTransactionTypes(), "Key", "Value");
                }
                return View(Dto);
            }
            catch (Exception ex)
            {
                await LogError(ex);
                return RedirectToAction("Error", "Error", new { area = "Account", statusCode = 500, errorMessage = ex.Message });
            }
        }

        //----- Delete -----
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                COADto Dto = await _Coa.GetByIdAsync(id);
                return View(Dto);
            }
            catch (Exception ex)
            {
                await LogError(ex);
                return RedirectToAction("Error", "Error", new { area = "Settings", statusCode = 500, errorMessage = ex.Message });
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _Coa.DeletesAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        //----- Detail -----
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                COADto Dto = await _Coa.GetByIdAsync(id);
                return View(Dto);
            }
            catch (Exception ex)
            {
                await LogError(ex);
                return RedirectToAction("Error", "Error", new { area = "Settings", statusCode = 500, errorMessage = ex.Message });
            }
        }


        //----- Update -----
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                COADto Dto = await _Coa.GetByIdAsync(id);
                if (Dto == null)
                {
                    return NotFound();
                }
                Dto.COADtoList = await _Coa.GetAllListAsync();
                Dto.BusinessCategoryList = await _companyBusinessCategoryRepository.GetAllCompanyBusinessCategoryAsync();
                Dto.CoatypeDtoList = await _CoaType.GetAllListAsync();
                Dto.CoaTransactionTypeList = new SelectList(_enumService.GetTransactionTypes(), "Key", "Value");
                return View(Dto);
            }
            catch (Exception ex)
            {
                await LogError(ex);
                return RedirectToAction("Error", "Error", new { area = "Settings", statusCode = 500, errorMessage = ex.Message });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, COADto Dto)
        {
            try
            {
                if (id != Dto.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    var result = await _Coa.UpdateAsync(Dto);
                    if (Dto == null)
                    {
                        return NotFound();
                    }
                    return RedirectToAction(nameof(Details), new { id = Dto.Id });
                }
                Dto.COADtoList = await _Coa.GetAllListAsync();
                Dto.BusinessCategoryList = await _companyBusinessCategoryRepository.GetAllCompanyBusinessCategoryAsync();
                Dto.CoatypeDtoList = await _CoaType.GetAllListAsync();
                Dto.CoaTransactionTypeList = new SelectList(_enumService.GetTransactionTypes(), "Key", "Value");
                return View(Dto);
            }
            catch (Exception ex)
            {
                await LogError(ex);
                return RedirectToAction("Error", "Error", new { area = "Settings", statusCode = 500, errorMessage = ex.Message });
            }
        }
        #endregion

        //=================== Partial Binding =====================
        #region Partial_Binding
        #endregion

        //=================== Error Logs =====================
        #region ErrorHandling
        private async Task LogError(Exception ex)
        {
            var (errorCode, statusCode) = ErrorUtility.GenerateErrorCodeAndStatus(ex);

            string areaName = ControllerContext.RouteData.Values["area"]?.ToString() ?? "Area Not Found";
            string controllerName = ControllerContext.RouteData.Values["controller"]?.ToString() ?? "Controler Not Found";
            string actionName = ControllerContext.RouteData.Values["action"]?.ToString() ?? "ActionName not Found";

            await _errorLogRepository.AddErrorLogAsync(
                area: areaName,
                controller: controllerName,
                actionName: actionName,
                formName: $"{actionName} Form",
                errorShortDescription: ex.Message,
                errorLongDescription: ErrorUtility.GetFullExceptionMessage(ex),
                statusCode: statusCode.ToString(),
                username: User.Identity?.Name ?? "GuestUser"
            );
        }
        #endregion
    }
}
