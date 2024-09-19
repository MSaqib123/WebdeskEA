using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebdeskEA.Domain.RepositoryDapper.IRepository;
using WebdeskEA.Domain.RepositoryEntity.IRepository;
using WebdeskEA.Domain.Service;
using WebdeskEA.Models.MappingModel;
using WebdeskEA.Utility;

namespace CRM.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UsersController : Controller
    {
        //_______ Constructor ______
        #region Constructor
        private readonly IApplicationUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IErrorLogRepository _errorLogRepository;

        public UsersController(
            IApplicationUserRepository userRepo,
            IMapper mapper,
            IImageService imageService,
            IErrorLogRepository errorLogRepository)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _imageService = imageService;
            _errorLogRepository = errorLogRepository ?? throw new ArgumentNullException(nameof(errorLogRepository));

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.NameOfForm = "User";
            base.OnActionExecuting(context);
        }

        #endregion

        //_______ Model Binding ______
        #region Module_Binding

        // GET: Users/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await _userRepo.GetAllUsersAsync();
                return View(users);
            }
            catch (Exception ex)
            {
                await LogError(ex, "Index");
                return RedirectToAction("Error", "Error", new { area = "Settings", statusCode = 500, errorMessage = ex.Message });
            }
        }

        // GET: Users/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationUserDto model, IFormFile profileImage)
        {
            try
            {
                ModelState.Remove("Id");
                //ModelState.Remove("ProfileImage");
                if (ModelState.IsValid)
                {
                    if (profileImage != null)
                    {
                        model.ProfileImage = _imageService.UploadImage(profileImage, "uploads/users");
                    }

                    var result = await _userRepo.AddAsync(model);

                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                await LogError(ex, "Create");
                return RedirectToAction("Error", "Error", new { area = "Settings", statusCode = 500, errorMessage = ex.Message });
            }
        }

        // GET: Users/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var user = await _userRepo.GetByIdAsync(id);
                if (user == null)
                    return NotFound();

                return View(user);
            }
            catch (Exception ex)
            {
                await LogError(ex, "Edit");
                return RedirectToAction("Error", "Error", new { area = "Settings", statusCode = 500, errorMessage = ex.Message });
            }
        }

        // POST: Users/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationUserDto model, IFormFile profileImage)
        {
            try
            {
                ModelState.Remove("ProfileImage");
                if (ModelState.IsValid)
                {
                    var user = await _userRepo.GetByIdAsync(model.Id);
                    if (user == null)
                        return NotFound();

                    // Preserve existing image if no new image is uploaded
                    if (profileImage != null)
                    {
                        _imageService.DeleteImage(user.ProfileImage, "uploads/users");
                        model.ProfileImage = _imageService.UploadImage(profileImage, "uploads/users");
                    }
                    else
                    {
                        // Preserve the existing image
                        model.ProfileImage = user.ProfileImage;
                    }

                    var result = await _userRepo.UpdateAsync(model);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                await LogError(ex, "Edit");
                return RedirectToAction("Error", "Error", new { area = "Settings", statusCode = 500, errorMessage = ex.Message });
            }
        }
        // GET: Users/Delete/{id}
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var user = await _userRepo.GetByIdAsync(id);
                if (user == null)
                    return NotFound();

                return View(user);
            }
            catch (Exception ex)
            {
                await LogError(ex, "Delete");
                return RedirectToAction("Error", "Error", new { area = "Settings", statusCode = 500, errorMessage = ex.Message });
            }
        }

        // POST: Users/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var user = await _userRepo.GetByIdAsync(id);
                if (user == null)
                    return NotFound();

                _imageService.DeleteImage(user.ProfileImage, "uploads/users");
                var result = await _userRepo.DeleteAsync(id);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(user);
                }
            }
            catch (Exception ex)
            {
                await LogError(ex, "DeleteConfirmed");
                return RedirectToAction("Error", "Error", new { area = "Settings", statusCode = 500, errorMessage = ex.Message });
            }
        }

        #endregion

        //_______ Error Log ______
        #region ErrorHandling
        private async Task LogError(Exception ex, string action)
        {
            var (errorCode, statusCode) = ErrorUtility.GenerateErrorCodeAndStatus(ex);
            await _errorLogRepository.AddErrorLogAsync(
                area: "Company",
                controller: "CompanyUserController",
                actionName: action,
                formName: $"{action} Form",
                errorShortDescription: ex.Message,
                errorLongDescription: ErrorUtility.GetFullExceptionMessage(ex),
                statusCode: statusCode.ToString(),
                username: User.Identity?.Name ?? "GuestUser"
            );
        }

        #endregion
    }

}
