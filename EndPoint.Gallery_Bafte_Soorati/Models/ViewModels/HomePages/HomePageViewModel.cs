using Gallery_Bafte_Soorati.Application.Services.HomePages.Queries;
using Gallery_Bafte_Soorati.Domain.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Gallery_Bafte_Soorati.Models.ViewModels.HomePages
{
    public class HomePageViewModel
    {
        public List<SliderDto> Sliders { get; set; }
        public List<HomePageDto> HomePageImages { get; set; }
        
    }
}
