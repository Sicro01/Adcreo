using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Adcreo.Controllers
{
    public class AboutController : SurfaceController
    {
        private const string _aboutReasonsTopPartialViewName = "_AboutSection";
       
        private string PartialViewPath(string name)
        {
            return $"~/Views/Partials/About/{name}.cshtml";
        }
        public ActionResult RenderAboutSection()
        {
            return PartialView(PartialViewPath(_aboutReasonsTopPartialViewName));
        }
    }
}