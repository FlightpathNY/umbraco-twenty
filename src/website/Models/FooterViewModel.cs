using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zone.UmbracoMapper;

namespace UmbracoTwenty.Models
{
    public class FooterViewModel
    {
        [PropertyMapping(SourceProperty = "Copyright")]
        public string Copyright { get; set; }

        [PropertyMapping(SourceProperty = "TwitterLink")]
        public string TwitterLink { get; set; }

        [PropertyMapping(SourceProperty = "FacebookLink")]
        public string FacebookLink { get; set; }

        [PropertyMapping(SourceProperty = "GooglePlusLink")]
        public string GooglePlusLink { get; set; }

        [PropertyMapping(SourceProperty = "GithubLink")]
        public string GithubLink { get; set; }

        [PropertyMapping(SourceProperty = "DribbleLink")]
        public string DribbleLink { get; set; }

        [PropertyMapping(SourceProperty = "Scripts")]
        public string Scripts { get; set; }
    }
}