using Gallery_Bafte_Soorati.Application.Services.HomePages.AddHomePages;
using Gallery_Bafte_Soorati.Domain.Entities.HomePages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Gallery_Bafte_Soorati.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AddHomePageController : Controller
    {
        private readonly IAddHomePageService addHomePageService;
        public AddHomePageController(IAddHomePageService _addHomePageService)
        {
            addHomePageService = _addHomePageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormFile File, string ImageLink, ImageLocation ImageLocation)
        {
            string mag = addHomePageService.Execute(new RequireForHomePage
            {
                ImageAddress = File,
                ImageLink = ImageLink,
                ImageLocation = ImageLocation,

            }).Message;
            return View(mag);
        }
    }
}
