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
            Mapper.AddCustomMapping(typeof(IList<CalloutViewModel>).FullName, MapCallouts)
                .Map(CurrentPage, model);
            MapBaseProperties(model);

            // if callouts is empty, load from level 2
            if (model.Callouts == null || model.Callouts.Count == 0)
            {
                Log.Debug("callouts is empty - loading from level 2.");
                BaseViewModel sectionModel = new BaseViewModel();
                IPublishedContent section = CurrentPage.AncestorOrSelf(2);
                Log.Debug("section: " + section.Name);
                Mapper.Map(section, sectionModel);
                model.Callouts = sectionModel.Callouts;
                Log.Debug("Callouts count: " + model.Callouts.Count);
            }
            else
            {
                Log.Debug("Callouts count: " + model.Callouts.Count);
            }

            // workaround for image not getting mapped
            IPublishedContent image = CurrentPage.GetPropertyValue<IPublishedContent>("featuredImage");
            if (image != null)
            {
                model.FeaturedImage = new MediaFile();
                model.FeaturedImage.Url = image.Url;
                model.FeaturedImage.Name = image.Name;
            }

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