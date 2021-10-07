using Gallery_Bafte_Soorati.Application.Interfaces.Storages;
using Gallery_Bafte_Soorati.Common.Dto;
using Gallery_Bafte_Soorati.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery_Bafte_Soorati.Application.Services.Categories.Commands
{
    public interface IAddCategoryService
    {
        ResultDto Execute(Guid? ParentId , string CategoryName);

    }

    public class AddCategoryService : IAddCategoryService
    {
        private readonly IStorage Storage;
        public AddCategoryService(IStorage _Storage)
        {
            Storage = _Storage;
        }
        public ResultDto Execute(Guid? ParentId, string CategoryName)
        {
            if (!string.IsNullOrWhiteSpace(CategoryName))
            {
                Category category = new()
                {
                    Name=CategoryName,
                    ParentCategory =Storage.Categories.Find(ParentId)
                };
                Storage.Categories.Add(category);
                Storage.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "دسته بندی اضافه شد.",
                };
            }
            return null;
        }
    }



}
