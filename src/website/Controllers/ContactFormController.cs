using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UmbracoTwenty.Models;

using log4net;
using System.Reflection;

namespace UmbracoTwenty.Controllers
{
    public class ContactFormController : Umbraco.Web.Mvc.SurfaceController
    {
        protected static ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        [ChildActionOnly]
        public ActionResult ShowContactForm()
        {
            ContactFormModel model = new ContactFormModel();
            return PartialView("ContactForm", model);
        }

        [HttpPost]
        public ActionResult SaveContactForm(ContactFormModel model)
        {
            Log.Debug("SaveContactForm() - name: " + model.Name + " email: " + model.Email + " subject: " + model.Subject);
             //model not valid, do not save, but return current umbraco page
            if (!ModelState.IsValid)
            {
                Log.Debug("Model state not valid.");
                //Perhaps you might want to add a custom message to the ViewBag
                //which will be available on the View when it renders (since we're not 
                //redirecting)          
                return CurrentUmbracoPage();
            }

            UmbracoTwenty.Persistence.ContactForm contactForm = new Persistence.ContactForm();
            contactForm.Save(model);

            //Add a message in TempData which will be available 
            //in the View after the redirect 
            TempData.Add("CustomMessage", "Your form was successfully submitted at " + DateTime.Now);

            //redirect to current page to clear the form
            return RedirectToCurrentUmbracoPage();          
        }
    }
}