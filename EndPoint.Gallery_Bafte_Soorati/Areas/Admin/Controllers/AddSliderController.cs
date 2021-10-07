using Gallery_Bafte_Soorati.Application.Services.HomePages.AddSlider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Gallery_Bafte_Soorati.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddSliderController : Controller
    {
        private readonly IAddSliderService AddSliderService;
        public AddSliderController(IAddSliderService _AddSliderService)
        {
            AddSliderService = _AddSliderService;
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
        public IActionResult Add(IFormFile File , string Link)
        {
            AddSliderService.Excute(File, Link);
            return View();
        }
    }
}
