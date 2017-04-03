using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Adcreo.Controllers
{
    public class WebsiteDesignAndBuildController : SurfaceController
    {
        private const string _websiteDesignAndBuildPartialViewName = "_WebsiteDesignAndBuildSection";

        private string PartialViewPath(string name)
        {
            return $"~/Views/Partials/WebsiteDesignAndBuild/{name}.cshtml";
        }
        public ActionResult RenderWebsiteDesignAndBuildSection()
        {
            return PartialView(PartialViewPath(_websiteDesignAndBuildPartialViewName));
        }
    }
}