using System.Web.Mvc;
using GreenPages.Web.Areas.BlogAdmin.Models;
using GreenPages.Web.Helpers;

namespace GreenPages.Web.Areas.BlogAdmin.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthProvider _authProvider;

        public AuthController()
        {
            _authProvider = PluginBlogConfig.GetAuthorization();
        }

        public AuthController(IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }

        public ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        public ActionResult Logout()
        {
            _authProvider.Logout();
            return Redirect("~/");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var login = _authProvider.Login(model.Username, model.Password);
                if (login)
                {
                    return RedirectToAction("Index", "Post");
                }
            }
            return View(model);
        }
	}
}