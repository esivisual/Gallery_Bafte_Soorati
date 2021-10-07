using Gallery_Bafte_Soorati.Application.Interfaces.Storages;
using Gallery_Bafte_Soorati.Common.Dto;
using Gallery_Bafte_Soorati.Domain.Entities.HomePages;
using System.Collections.Generic;
using System.Linq;

namespace Gallery_Bafte_Soorati.Application.Services.HomePages.Queries
{
    public interface IGetHomePageSevice
    {
        ResultDto<List<HomePageDto>> Execute();

    }


    public class GetHomePageSevice : IGetHomePageSevice
    {
        private readonly IStorage Storage;
        public GetHomePageSevice(IStorage _Storage)
        {
            Storage = _Storage;
        }
        public ResultDto<List<HomePageDto>> Execute()
        {
            var HomePageImages = Storage.HomePageImages.Select(p => new HomePageDto
            {
                ImageAddress = p.ImageAddress,
                ImagePosition = p.ImagePosition,
                Refer = p.Refer,
            }).ToList();
            return new ResultDto<List<HomePageDto>>
            {
                Data = HomePageImages,
                IsSuccess = true,
                Message = "",
            };
        }
    }
    public class HomePageDto
    {
        public string ImageAddress { get; set; }
        public string Refer { get; set; }
        public ImageLocation ImagePosition { get; set; }
    }
}
