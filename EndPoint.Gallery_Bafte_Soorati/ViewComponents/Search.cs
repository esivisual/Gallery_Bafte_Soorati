using Gallery_Bafte_Soorati.Application.Services.Categories.Queriess.GetCategory;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EndPoint.Gallery_Bafte_Soorati.ViewComponents
{
    public class Search : ViewComponent
    {
        private readonly IGetCategoryService GetCategory;
        public Search(IGetCategoryService _getCategory)
        {
            GetCategory = _getCategory;
        }

        public IViewComponentResult Invoke(Guid? ParendId)
        {
            var GetCategories = GetCategory.Execute(ParendId).Data;
            return View(viewName: "Search", GetCategories);
        }
    }
}
