using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zone.UmbracoMapper;

namespace UmbracoTwenty.Models
{
    public class LandingPageViewModel : BaseViewModel
    {
        public LandingPageViewModel()
        {
            MainCallouts = new List<CalloutViewModel>();
        }

        [PropertyMapping(SourceProperty = "Heading")]
        public string Heading { get; set; }

        [PropertyMapping(SourceProperty = "SubHeading")]
        public string SubHeading { get; set; }

        public IList<CalloutViewModel> MainCallouts { get; set; }

    }
}