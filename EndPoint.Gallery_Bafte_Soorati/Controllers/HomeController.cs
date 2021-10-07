using EndPoint.Gallery_Bafte_Soorati.Models;
using EndPoint.Gallery_Bafte_Soorati.Models.ViewModels.HomePages;
using Gallery_Bafte_Soorati.Application.Services.HomePages.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace EndPoint.Gallery_Bafte_Soorati.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetSliderService GetSlider;
        private readonly IGetHomePageSevice GetHomePage;

        public HomeController(ILogger<HomeController> logger, IGetSliderService getSlider, IGetHomePageSevice getHomePage)
        {
            _logger = logger;
            GetSlider = getSlider;
            GetHomePage = getHomePage;
        }

        public IActionResult Index()
        {
            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = GetSlider.Execute().Data,
                HomePageImages = GetHomePage.Execute().Data,
            };
            return View(homePage);
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
