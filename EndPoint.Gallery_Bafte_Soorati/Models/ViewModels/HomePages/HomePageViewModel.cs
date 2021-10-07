using Gallery_Bafte_Soorati.Application.Services.HomePages.Queries;
using System.Collections.Generic;

namespace EndPoint.Gallery_Bafte_Soorati.Models.ViewModels.HomePages
{
    public class HomePageViewModel
    {
        public List<SliderDto> Sliders { get; set; }
        public List<HomePageDto> HomePageImages { get; set; }

    }
}
