using WebdeskEA.Domain.Service;
using WebdeskEA.Models.ExternalModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebdeskEA.Domain.RepositoryEntity.IRepository;
using WebdeskEA.Models.MappingModel;

namespace WebdeskEA.ViewComponents
{
    [Authorize]
    public class HeaderViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IImageService _imageService;
        private readonly IApplicationUserRepository _applicationUserRepository;

        public HeaderViewComponent(UserManager<ApplicationUser> userManager, IImageService imageService, IApplicationUserRepository applicationUserRepository)
        {
            _userManager = userManager;
            _imageService = imageService;
            _applicationUserRepository = applicationUserRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = User.Identity.Name;
            if (userId != null)
            {
                var user = await _userManager.FindByNameAsync(userId);
                var profileImageUrl = user != null ? _imageService.GetImagePath(user.ProfileImage, "~/uploads/users/") : "~/Template/img/profiles/default.jpg";
                return View(new HeaderViewModel
                {
                    ProfileImageUrl = profileImageUrl,
                    UserName = user.UserName,
                    Name = user.Name
                });
            }
            return View(new HeaderViewModel
            {
                ProfileImageUrl = "~/Template/img/profiles/default.jpg"
            });
        }
    }
}
