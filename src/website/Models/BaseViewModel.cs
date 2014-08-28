using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zone.UmbracoMapper;

namespace UmbracoTwenty.Models
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            Callouts = new List<CalloutViewModel>();
        }

        [PropertyMapping(SourceProperty = "PageTitle")]
        public string PageTitle { get; set; }

        [PropertyMapping(SourceProperty = "Description")]
        public string Description { get; set; }

        [PropertyMapping(SourceProperty = "CalloutsDisplayImages")]
        public bool CalloutsDisplayImages { get; set; }

        [PropertyMapping(SourceProperty = "CalloutsDisplayButtons")]
        public bool CalloutsDisplayButtons { get; set; }

        public IList<CalloutViewModel> Callouts { get; set; }

        public IList<MenuItemViewModel> LeftMenuItems { get; set; }

        public IList<MenuItemViewModel> RightMenuItems { get; set; }

        public FooterViewModel Footer { get; set; }
    }
}