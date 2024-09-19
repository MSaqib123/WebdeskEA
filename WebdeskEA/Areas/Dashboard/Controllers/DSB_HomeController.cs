using WebdeskEA.Models.Models;
using WebdeskEA.Utility.AttributeUtality;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace WebdeskEA.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class DSB_HomeController : Controller
    {

        private readonly ILogger<DSB_HomeController> _logger;
        private readonly IWebHostEnvironment _iWeb;

        public DSB_HomeController(
            ILogger<DSB_HomeController> logger,
            IWebHostEnvironment iWeb)
        {
            _logger = logger;
            _iWeb = iWeb;
        }

        public IActionResult Index()
        {
            return View();
        }

        private bool HasPermission(int permissions, int permissionIndex)
        {
            return (permissions & (1 << permissionIndex)) != 0;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
