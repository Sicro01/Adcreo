using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Adcreo.Models;
using Umbraco.Core.Models;
using System.Runtime.Caching;

namespace Adcreo.Controllers
{
    public class SiteLayoutController : SurfaceController
    {
        private const string _headerPartialViewName = "_Header";
        private const string _footerPartialViewName = "_Footer";
        private string PartialViewPath(string name)
        {
            return $"~/Views/Partials/SiteLayout/{name}.cshtml";
        }

        public ActionResult RenderFooter()
        {
            return PartialView(PartialViewPath(_footerPartialViewName));
        }

        /// <summary>
        /// Renders the top navigation on the _Header partial
        /// </summary>
        /// <returns>Partial view with a model</returns>
        public ActionResult RenderHeader()
        {
            //List<NavigationListItem> nav = GetNavigationModelFromDatabase();
            List<NavigationListItemModel> nav = GetObjectFromCache<List<NavigationListItemModel>>("mainNav", 5, GetNavigationModelFromDatabase);
            return PartialView(PartialViewPath(_headerPartialViewName), nav);
        }

        /// <summary>
        /// Finds the home page and gets the navigation structure based on it and it's children
        /// </summary>
        /// <returns>A List of NavigationListItems, representing the structure of the site.</returns>
        private List<NavigationListItemModel> GetNavigationModelFromDatabase()
        {
            const int HOME_PAGE_POSITION_IN_PATH = 1;
            int homePageId = int.Parse(CurrentPage.Path.Split(',')[HOME_PAGE_POSITION_IN_PATH]);
            IPublishedContent homePage = Umbraco.Content(homePageId);
            List<NavigationListItemModel> nav = new List<NavigationListItemModel>();
            nav.Add(new NavigationListItemModel(new NavigationLinkModel(homePage.Url, homePage.Name)));
            nav.AddRange(GetChildNavigationList(homePage));
            return nav;
        }

        /// <summary>
        /// Loops through the child pages of a given page and their children to get the structure of the site.
        /// </summary>
        /// <param name="page">The parent page which you want the child structure for</param>
        /// <returns>A List of NavigationListItems, representing the structure of the pages below a page.</returns>
        private List<NavigationListItemModel> GetChildNavigationList(dynamic page)
        {
            List<NavigationListItemModel> listItems = null;
            var childPages = page.Children.Where("Visible");
            if (childPages != null && childPages.Any() && childPages.Count() > 0)
            {
                listItems = new List<NavigationListItemModel>();
                foreach (var childPage in childPages)
                {
                    NavigationListItemModel listItem = new NavigationListItemModel(new NavigationLinkModel(childPage.Url, childPage.Name));
                    listItem.Items = GetChildNavigationList(childPage);
                    listItems.Add(listItem);
                }
            }
            return listItems;
        }

        /// <summary>
        /// A generic function for getting and setting objects to the memory cache.
        /// </summary>
        /// <typeparam name="T">The type of the object to be returned.</typeparam>
        /// <param name="cacheItemName">The name to be used when storing this object in the cache.</param>
        /// <param name="cacheTimeInMinutes">How long to cache this object for.</param>
        /// <param name="objectSettingFunction">A parameterless function to call if the object isn't in the cache and you need to set it.</param>
        /// <returns>An object of the type you asked for</returns>
        private static T GetObjectFromCache<T>(string cacheItemName, int cacheTimeInMinutes, Func<T> objectSettingFunction)
        {
            ObjectCache cache = MemoryCache.Default;
            var cachedObject = (T)cache[cacheItemName];
            if (cachedObject == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cacheTimeInMinutes);
                cachedObject = objectSettingFunction();
                cache.Set(cacheItemName, cachedObject, policy);
            }
            return cachedObject;
        }
    }
}