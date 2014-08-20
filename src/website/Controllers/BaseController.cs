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
    //using Zone.UmbracoMapper.DampCustomMapping;
    using UmbracoTwenty.Models;
    using Archetype.Models;
    using System.Linq;


    public abstract class BaseController : SurfaceController, IRenderMvcController
    {
        protected IUmbracoMapper Mapper { get; set; }
        public BaseController(IUmbracoMapper mapper)
        {
            Mapper = mapper;
            //Mapper.AddCustomMapping(typeof(MediaFile).FullName, DampMapper.MapMediaFile);
            //Mapper.MapCollection(CurrentPage, )
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

        protected void MapCallouts(BaseViewModel model)
        {
            Mapper.AddCustomMapping(typeof(IList<CalloutViewModel>).FullName,
                MapCallouts);
        }

        protected void MapFooter(BaseViewModel model)
        {
            var homePage = CurrentPage.AncestorOrSelf(1);
            FooterViewModel footer = new FooterViewModel();
            Mapper.Map(homePage, footer);
            model.Footer = footer;
        }

        public static object MapCallouts(IUmbracoMapper mapper, IPublishedContent contentToMapFrom, string propName, bool isRecursive)
        {
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
            switch (archetypeProperty.PropertyEditorAlias)
            {
                case "Umbraco.ContentPickerAlias":
                case "Umbraco.MediaPicker":
                    return archetypeProperty.GetValue<IPublishedContent>();
                case "Umbraco.MultiNodeTreePicker":
                    return archetypeProperty.GetValue<IEnumerable<IPublishedContent>>();
                default:
                    return archetypeProperty.Value;
            }
        }
    }
}
