using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Adcreo.Models;

namespace Adcreo.Controllers
{
    public class HomeController : SurfaceController
    {

        private const string _tagLinePartialViewName = "_ImageAndTagLine";
        private const string _weAreAboutPartialViewName = "_WeAreAbout";
        private const string _homeServicesPartialViewName = "_HomeServices";
        private string PartialViewPath(string name)
        {
            return $"~/Views/Partials/Home/{name}.cshtml";
        }

        public ActionResult RenderTagLine()
        {
            return PartialView(PartialViewPath(_tagLinePartialViewName));
        }

        public ActionResult RenderWeAreAbout()
        {
            IPublishedContent homePage = CurrentPage.AncestorOrSelf("home");
            string title = homePage.GetPropertyValue<string>("weAreAboutTitle");
            string bodyText = homePage.GetPropertyValue("weAreAboutBodyText").ToString();

            WeAreAboutModel model = new WeAreAboutModel(title, bodyText);
            return PartialView(PartialViewPath(_weAreAboutPartialViewName), model);
        }

        public ActionResult RenderHomeServices()
        {
            return PartialView(PartialViewPath(_homeServicesPartialViewName));
        }
    }
}