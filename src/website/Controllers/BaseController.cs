namespace UmbracoTwenty.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;
    using System;

    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Umbraco.Web.Models;
    using Umbraco.Web.Mvc;
    using Zone.UmbracoMapper;
    using UmbracoTwenty.Models;
    using Archetype.Models;
    using System.Linq;

    using log4net;
    using System.Reflection;


    public abstract class BaseController : SurfaceController, IRenderMvcController
    {
        protected static ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected IUmbracoMapper Mapper { get; set; }
        public BaseController(IUmbracoMapper mapper)
        {
            Mapper = mapper;
        }

        #region IRenderMvcController methods

        protected ActionResult CurrentTemplate<T>(T model)
        {
            return View(ControllerContext.RouteData.Values["action"].ToString(), model);
        }

        public virtual ActionResult Index(RenderModel model)
        {
            return CurrentTemplate(model);
        }

        #endregion

        //protected void MapCallouts(BaseViewModel model)
        //{
        //    Mapper.AddCustomMapping(typeof(IList<CalloutViewModel>).FullName,
        //        MapCallouts);
        //}

        protected void MapBaseProperties(BaseViewModel model)
        {
            var homePage = CurrentPage.AncestorOrSelf(1);

            FooterViewModel footer = new FooterViewModel();
            Mapper.Map(homePage, footer);
            //.AddCustomMapping(typeof(IList<MenuItemViewModel>).FullName, MapMenuItems)
            model.Footer = footer;


        }

        public static object MapMenuItems(IUmbracoMapper mapper, IPublishedContent contentToMapFrom, string propName, bool isRecursive)
        {
            Log.Debug("MapMenuItems() called.  propName: " + propName);
            var result = new List<MenuItemViewModel>();

            ArchetypeModel archetypeModel = contentToMapFrom.GetPropertyValue<ArchetypeModel>(propName, isRecursive, null);
            if (archetypeModel != null)
            {
                var archetypeAsDictionary = archetypeModel
                    .Select(item => item.Properties.ToDictionary(m => m.Alias, m => GetTypedValue(m), StringComparer.InvariantCultureIgnoreCase))
                    .ToList();
                mapper.MapCollection<MenuItemViewModel>(archetypeAsDictionary, result);
            }

            return result;
        }

        public static object MapCallouts(IUmbracoMapper mapper, IPublishedContent contentToMapFrom, string propName, bool isRecursive)
        {
            Log.Debug("MapCallouts() called.  propName: " + propName);
            var result = new List<CalloutViewModel>();

            ArchetypeModel archetypeModel = contentToMapFrom.GetPropertyValue<ArchetypeModel>(propName, isRecursive, null);
            if (archetypeModel != null)
            {
                var archetypeAsDictionary = archetypeModel
                    .Select(item => item.Properties.ToDictionary(m => m.Alias, m => GetTypedValue(m), StringComparer.InvariantCultureIgnoreCase))
                    .ToList();
                mapper.MapCollection(archetypeAsDictionary, result);
            }

            return result;
        }

        private static object GetTypedValue(ArchetypePropertyModel archetypeProperty)
        {
            Log.Debug("GetTypedValue(ArchetypePropertyModel archetypeProperty)");
            Log.Debug(archetypeProperty.PropertyEditorAlias + " " + archetypeProperty.Alias +" ["+ archetypeProperty.Value + "]");

            switch (archetypeProperty.PropertyEditorAlias)
            {
                case "Umbraco.ContentPickerAlias":
                case "Umbraco.MediaPicker":
                    IPublishedContent v = archetypeProperty.GetValue<IPublishedContent>();
                    if (v == null)
                    {
                        Log.Debug("IPublishedContent is null");
                        Log.Debug("value: " + archetypeProperty.Value);
                        return "";
                    }
                    return v;
                //case "Umbraco.MultiNodeTreePicker":
                //    return archetypeProperty.GetValue<IEnumerable<IPublishedContent>>();
                default:
                    return archetypeProperty.Value;
            }
        }
    }
}
