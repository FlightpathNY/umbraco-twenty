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
    //using log4net;
    //using System.Reflection;

    public class HomeController : BaseController
    {
        public HomeController(IUmbracoMapper mapper)
            : base(mapper)
        {
            //Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            Mapper.AddCustomMapping(typeof(IList<CalloutViewModel>).FullName,
                MapCallouts).Map(CurrentPage, model);
            MapFooter(model);

            return CurrentTemplate(model);
        }

    }
}