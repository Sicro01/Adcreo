using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adcreo.Models
{
    public class WeAreAboutModel
    {
        public string WeAreAboutTitle { get; set; }
        public string WeAreAboutBodyText { get; set; }

        public WeAreAboutModel(string weAreAboutTitle, string weAreAboutBodyText)
        {
            WeAreAboutTitle = weAreAboutTitle;
            WeAreAboutBodyText = weAreAboutBodyText;
        }
    }
}