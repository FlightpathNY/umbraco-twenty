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
    using Archetype.Models;
    using Archetype.Extensions;

    public class HomeController : BaseController
    {
        public HomeController(IUmbracoMapper mapper)
            : base(mapper)
        {

        }

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            Mapper.AddCustomMapping(typeof(IList<CalloutViewModel>).FullName,
                MapCallouts).AddCustomMapping(typeof(IList<MenuItemViewModel>).FullName, MapMenuItems).Map(CurrentPage, model);
            MapBaseProperties(model);

            return CurrentTemplate(model);
        }

    }
}