using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adcreo.Models
{
    public class NavigationLinkModel
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public bool NewWindow { get; set; }
        public string Target { get { return NewWindow ? "_blank" : null; } }
        public string Title { get; set; }

        public NavigationLinkModel()
        { }

        public NavigationLinkModel(string url, string text = null, bool newWindow = false, string title = null)
        {
            Text = text;
            Url = url;
            NewWindow = newWindow;
            Title = title;
        }
    }
}
