namespace UmbracoTwenty.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Mvc;
    using System.Xml.Linq;
    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Zone.UmbracoMapper;
    using UmbracoTwenty.Models;

    using Umbraco.Web.Models;
    using Umbraco.Web.Mvc;

    public class HomeController : BaseController
    {
        public HomeController(IUmbracoMapper mapper)
            : base(mapper)
        {
        }

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            Mapper.Map(CurrentPage, model);
            MapFooter(model);

            return CurrentTemplate(model);
        }

    }
}