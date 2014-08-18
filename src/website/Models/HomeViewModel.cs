﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zone.UmbracoMapper;

namespace UmbracoTwenty.Models
{
    public class HomeViewModel : BaseViewModel
    {
        [PropertyMapping(SourceProperty="BannerTitle")]
        public string BannerTitle { get; set; }

        [PropertyMapping(SourceProperty="BannerCopy")]
        public string BannerCopy { get; set; }

        [PropertyMapping(SourceProperty = "BannerButtonText")]
        public string BannerButtonText { get; set; }
    }
}