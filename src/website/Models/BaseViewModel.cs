using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoTwenty.Models
{
    public class BaseViewModel
    {
        public string PageTitle { get; set; }
        public string Description { get; set; }
        public FooterViewModel Footer { get; set; }
    }
}