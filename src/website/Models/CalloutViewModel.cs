using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoTwenty.Models
{
    public class CalloutViewModel
    {
        public CalloutViewModel()
        {
            Image = new Zone.UmbracoMapper.MediaFile();
        }
        public Zone.UmbracoMapper.MediaFile Image { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string LinkText { get; set; }
    }
}