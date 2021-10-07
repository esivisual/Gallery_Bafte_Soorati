using Gallery_Bafte_Soorati.Application.Interfaces.Storages;
using Gallery_Bafte_Soorati.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gallery_Bafte_Soorati.Application.Services.Categories.Queriess.GetCategory
{
    public interface IGetCategoryService
    {
        ResultDto<List<CategoryDto>> Execute(Guid? ParentID);
    }

    public class GetCategoryService : IGetCategoryService
    {
        private readonly IStorage Storage;
        public GetCategoryService(IStorage _Storage)
        {
            Storage = _Storage;
        }
        public ResultDto<List<CategoryDto>> Execute(Guid? ParentID)
        {
            var Categories = Storage.Categories
                .Include(p => p.ParentCategory)
                .Include(p => p.SubCategory)
                .Where(p => p.ParentCategoryId == ParentID).ToList()
                .Select(p => new CategoryDto
                {
                    Id = p.ParentCategoryId,
                    Name = p.Name,
                    Parent = p.ParentCategory != null ? new ParentCategoryDto
                    {
                        Id = p.ParentCategory.Id,
                        Name = p.ParentCategory.Name,
                    } : null,
                    HasChild = p.SubCategory.Count() > 0 ? true : false,
                }).ToList();

            return new ResultDto<List<CategoryDto>>
            {
                Data = Categories,
                IsSuccess = true,
                Message = "",
            };
        }
    }
    public class CategoryDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public ParentCategoryDto Parent { get; set; }


    }
    public class ParentCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
