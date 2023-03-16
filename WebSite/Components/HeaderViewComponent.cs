using Microsoft.AspNetCore.Mvc;

namespace WebSite.Components
{
    public class HeaderViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Header");
        }
    }
}