using Microsoft.AspNetCore.Mvc;

namespace WebSite.Components
{
    public class FooterViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Footer");
        }
    }
}