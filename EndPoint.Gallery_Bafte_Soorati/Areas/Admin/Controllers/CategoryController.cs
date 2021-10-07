using Gallery_Bafte_Soorati.Application.Services.Categories.Commands;
using Gallery_Bafte_Soorati.Application.Services.Categories.Queriess.GetCategory;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EndPoint.Gallery_Bafte_Soorati.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IAddCategoryService AddCategory;
        private readonly IGetCategoryService GetCategory;
        public CategoryController(IAddCategoryService _addCategory, IGetCategoryService _getCategory)
        {
            AddCategory = _addCategory;
            GetCategory = _getCategory;
        }
        public IActionResult Index(Guid? ParentId)
        {
            return View(GetCategory.Execute(ParentId).Data);
        }

        [HttpGet]
        public IActionResult AddNewCategory(Guid? ParentId)
        {
            ViewBag.ParentId = ParentId;
            return View();
        }
        [HttpPost]
        public IActionResult AddNewCategory(Guid? ParentId, string Name)
        {
            var Result = AddCategory.Execute(ParentId, Name);
            return Json(Result);
        }
    }
}
