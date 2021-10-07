using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Gallery_Bafte_Soorati.ViewComponents
{
    public class GetMenu : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
