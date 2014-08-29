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

    public class LandingPageController : BaseController
    {
        public LandingPageController(IUmbracoMapper mapper)
            : base(mapper)
        {

        }

        public ActionResult Index()
        {
            LandingPageViewModel model = new LandingPageViewModel();
            Mapper.AddCustomMapping(typeof(IList<CalloutViewModel>).FullName, MapCallouts)
                .Map(CurrentPage, model);
            MapBaseProperties(model);

            HomeViewModel home = new HomeViewModel();
            IPublishedContent root = CurrentPage.AncestorOrSelf(1);
            Mapper//.AddCustomMapping(typeof(IList<CalloutViewModel>).FullName, MapCallouts)
                .AddCustomMapping(typeof(IList<MenuItemViewModel>).FullName, MapMenuItems)
                .Map(root, home);
            model.Root = home;

            return CurrentTemplate(model);
        }

    }
}