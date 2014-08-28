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

namespace UmbracoTwenty.Controllers
{
    public class ArticleController : BaseController
    {
        public ArticleController(IUmbracoMapper mapper)
            : base(mapper)
        {
        }

        public ActionResult Index()
        {
            ArticleViewModel model = new ArticleViewModel();
            Mapper.Map(CurrentPage, model);
            MapBaseProperties(model);

            HomeViewModel home = new HomeViewModel();
            IPublishedContent root = CurrentPage.AncestorOrSelf(1);
            Mapper.AddCustomMapping(typeof(IList<CalloutViewModel>).FullName, MapCallouts)
                .AddCustomMapping(typeof(IList<MenuItemViewModel>).FullName, MapMenuItems)
                .Map(root, home);
            model.Root = home;

            return CurrentTemplate(model);
        }
    }
}