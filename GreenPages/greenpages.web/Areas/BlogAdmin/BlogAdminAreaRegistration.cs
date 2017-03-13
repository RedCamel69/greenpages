using System.Web.Mvc;

namespace GreenPages.Web.Areas.BlogAdmin
{
    public class BlogAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BlogAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BlogAdmin_default",
                "BlogAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "GreenPages.Web.Areas.BlogAdmin.Controllers" }
            );
        }
    }
}