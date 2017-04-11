using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Adcreo.Controllers
{
    public class BusinessConsultancyController : SurfaceController
    {
        private const string _businessConsultancyPartialViewName = "_BusinessConsultancy";
      
        private string PartialViewPath(string name)
        {
            return $"~/Views/Partials/Services/{name}.cshtml";
        }

        public ActionResult RenderBusinessConsultancySection()
        {
            return PartialView(PartialViewPath(_businessConsultancyPartialViewName));
        }
    }
}