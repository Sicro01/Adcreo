using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Adcreo.Controllers
{
    public class ServicesController : SurfaceController
    {
        private const string _servicesPartialViewName = "_ServicesSection";

        private string PartialViewPath(string name)
        {
            return $"~/Views/Partials/Services/{name}.cshtml";
        }
        public ActionResult RenderServicesSection()
        {
            return PartialView(PartialViewPath(_servicesPartialViewName));
        }
    }
}