using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adcreo.Models
{
    public class NavigationListItemModel
    {
        public string Text { get; set; }
        public NavigationLinkModel Link { get; set; }
        public List<NavigationListItemModel> Items { get; set; }
        public bool HasChildren { get { return Items != null && Items.Any() && Items.Count > 0; } }

        public NavigationListItemModel()
        { }

        public NavigationListItemModel(NavigationLinkModel link)
        {
            Link = link;
        }

        public NavigationListItemModel(string text)
        {
            Text = text;
        }
    }
}