using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Gallery_Bafte_Soorati.ViewComponents
{
    public class GetMenu : ViewComponent 
    {

        public IViewComponentResult  Invoke()
        {
            return View();
        }

    }
}
