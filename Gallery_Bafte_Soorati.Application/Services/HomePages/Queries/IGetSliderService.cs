using Gallery_Bafte_Soorati.Application.Interfaces.Storages;
using Gallery_Bafte_Soorati.Common.Dto;
using Gallery_Bafte_Soorati.Domain.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery_Bafte_Soorati.Application.Services.HomePages.Queries
{
    public interface IGetSliderService
    {
        ResultDto<List<SliderDto>> Execute();

    }

    public class GetSliderService : IGetSliderService
    {
        private readonly IStorage Storage;
        public GetSliderService(IStorage _Storage)
        {
            Storage = _Storage;
        }
        public ResultDto<List<SliderDto>> Execute()
        {
            var Sliders = Storage.Sliders.OrderByDescending(p => p.InsertTime).ToList().Select(p => new SliderDto
            {
                ImageAddress =p.ImageAddress ,
                Link=p.Refer,
            }).ToList();

            return new ResultDto<List<SliderDto>>
            {
                Data = Sliders,
                IsSuccess = true,
                Message = "",
            };
            
        }
    }

    public class SliderDto
    {
        public string ImageAddress { get; set; }
        public string Link { get; set; }

    }
}
