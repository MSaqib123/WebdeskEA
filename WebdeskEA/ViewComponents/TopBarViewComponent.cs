using WebdeskEA.Domain.RepositoryDapper.IRepository;
using WebdeskEA.Models.MappingModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebdeskEA.Domain.Service;
using Microsoft.AspNetCore.Identity;
using WebdeskEA.Models.ExternalModel;

namespace WebdeskEA.ViewComponents
{
    [Authorize]
    public class TopBarViewComponent : ViewComponent
    {
        private readonly IModuleRepository _ModuleRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IImageService _imageService;
        public TopBarViewComponent(IModuleRepository ModuleRepo, UserManager<ApplicationUser> userManager, IImageService imageService)
        {
            _ModuleRepo = ModuleRepo;
            _imageService = imageService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsPrincipal = User as ClaimsPrincipal;
            var userId = claimsPrincipal?.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.Identity.Name;

            //================ Dyanamic SideBar =================
            #region SideBar
            if (userId == null)
            {
                return View(new ModuleDto()); // Returning an empty ModuleDto if no userId
            }

            List<ModuleDto> listmenu = new List<ModuleDto>();
            var module = await _ModuleRepo.GetUserSideBarOnlyFormMenuByUserId(userId);
            foreach (var item in module)
            {
                ModuleDto m = new ModuleDto
                {
                    ModuleName = item.ModuleName,
                    ModuleUrl = item.ModuleUrl,
                    ModuleIcon = item.ModuleIcon,
                    ParentModuleId = item.ParentModuleId
                };
                listmenu.Add(m);
            }
            ModuleDto vm = new ModuleDto
            {
                MenuList = listmenu,
                ModuleList = await _ModuleRepo.GetAllListAsync(),
            };
            #endregion


            //================ User Detail for TopBaNavbar =================
            #region Userdetail
            var user = await _userManager.FindByNameAsync(userName);
            var profileImageUrl = user != null ? _imageService.GetImagePath(user.ProfileImage, "~/uploads/users/") : "~/Template/img/profiles/default.jpg";
            var userDetail = new HeaderViewModel
            {
                ProfileImageUrl = profileImageUrl,
                UserName = user.UserName,
                Name = user.Name,
                moduleDto = vm
            };
            #endregion


            return View(userDetail);
        }
    }
}

