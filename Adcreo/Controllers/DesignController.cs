using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Adcreo.Controllers
{
    public class DesignController : SurfaceController
    {
        private const string _designPartialViewName = "_DesignSection";

        private string PartialViewPath(string name)
        {
            return $"~/Views/Partials/Services/{name}.cshtml";
        }
        public ActionResult RenderDesignSection()
        {
            return PartialView(PartialViewPath(_designPartialViewName));
        }
    }
}