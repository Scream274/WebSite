using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Components.AdminWidgets
{
    public class FooterAdmViewComponent : ViewComponent
    {

        public FooterAdmViewComponent()
        {
            
        }
        public IViewComponentResult Invoke()
        {
            return View("FooterAdm");
        }
    }
}
