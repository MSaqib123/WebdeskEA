using WebdeskEA.Models.MappingModel;

namespace WebdeskEA.ViewComponents
{
    public class HeaderViewModel
    {
        public HeaderViewModel()
        {
            moduleDto = new ModuleDto();
        }
        public string ProfileImageUrl { get; set; }
        public string UserName { get; set; }
        public string Name { get;set; }

        public ModuleDto moduleDto { get; set; }
    }
}
