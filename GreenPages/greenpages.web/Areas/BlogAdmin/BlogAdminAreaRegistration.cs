using System.Web.Mvc;

namespace GreenPages.WEb.Areas.BlogAdmin
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
                new[] { "GreenPages.WEb.Areas.BlogAdmin.Controllers" }
            );
        }
    }
}