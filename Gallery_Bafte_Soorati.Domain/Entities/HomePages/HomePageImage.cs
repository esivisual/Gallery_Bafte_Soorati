using Gallery_Bafte_Soorati.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery_Bafte_Soorati.Domain.Entities.HomePages
{
    public class HomePageImage : BaseEntity
    {
        public string ImageAddress { get; set; }
        public string Refer { get; set; }
        public ImageLocation ImagePosition { get; set; }
    }

    public enum ImageLocation
    {
        L0 = 1,
        L1 = 2,
        R1 = 3,
        CenterFullScreen = 4,
        G1 = 5,
        G2 = 6
    }
}
