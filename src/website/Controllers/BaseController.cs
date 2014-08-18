namespace UmbracoTwenty.Controllers
{
    using System.Web.Mvc;
    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Umbraco.Web.Models;
    using Umbraco.Web.Mvc;
    using Zone.UmbracoMapper;
    //using Zone.UmbracoMapper.DampCustomMapping;
    using UmbracoTwenty.Models;

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


        protected void MapFooter(BaseViewModel model)
        {
            var homePage = CurrentPage.AncestorOrSelf(1);
            FooterViewModel footer = new FooterViewModel();
            Mapper.Map(homePage, footer);
            model.Footer = footer;
        }
    }
}
