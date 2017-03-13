using System.Linq;
using System.Web.Mvc;
using GreenPages.Web.Areas.BlogAdmin.Models;
using GreenPages.Web.Helpers;

namespace GreenPages.Web.Areas.BlogAdmin.Controllers
{
    public class BaseBlogController : Controller
    {
        public const int PAGE_SIZE = 10;

         protected override void OnActionExecuting(ActionExecutingContext filterContext)
         {
             var authProvider = PluginBlogConfig.GetAuthorization();
             //if not authorized redirect to home
             if (authProvider.IsLoggedIn == false)
             {
                 //filterContext.Result = new RedirectResult(Url.Content("~/"));
                 filterContext.Result = new RedirectResult(Url.Action("Login","Auth"));
             }
         }

        protected void ShowErrors()
        {
            var errors = ModelState.Values.SelectMany(x => x.Errors).ToArray();
            foreach (var error in errors)
            {
                ModelState.AddModelError("", error.ErrorMessage + "" + error.Exception);
            }
        }

        public void SetDbMessage(bool success, string message)
        {
            
                TempData["dbMessage"] = new DbMessage()
                {
                    Message =
                        message,
                    Success = success
                };
            
        }
	}
}