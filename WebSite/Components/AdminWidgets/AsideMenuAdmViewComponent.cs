using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Components.AdminWidgets
{
    public class AsideMenuAdmViewComponent : ViewComponent
    {

        public AsideMenuAdmViewComponent()
        {
            
        }
        public IViewComponentResult Invoke()
        {
            return View("AsideMenuAdm");
        }
    }
}
