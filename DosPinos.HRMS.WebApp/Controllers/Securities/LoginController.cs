using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Interfaces.Securities;
using DosPinos.HRMS.WebApp.Helpers;
using DosPinos.HRMS.WebApp.Models.Securities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DosPinos.HRMS.WebApp.Controllers.Securities
{
    [Route("acceso")]
    public class LoginController(HRMS.Controllers.Securities.UserController userController) : Controller
    {
        private readonly HRMS.Controllers.Securities.UserController _userController = userController;

        public IActionResult Index(LoginViewModel model) => User.Identity.IsAuthenticated ? Redirect("~/Dashboard/Index") : View(model);

        [HttpPost]
        [Route("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (User.Identity.IsAuthenticated) Redirect("~/Dashboard/Index");

            //Predefined user for these cases
            model.UserObj.UserId = 1;

            var response = await _userController.ProcessAsync(model.UserObj);

            if (response.Status != ResponseStatus.Success)
            {
                model.Response = response;
                return View("Index", model);
            }

            await CookiesHelper.CreateAuthenticationCookies(HttpContext, (ILoginUserDTO)response.Content);
            return RedirectToAction("Index", "Dashboard");
        }

        [Authorize]
        [HttpPost]
        [Route("logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await CookiesHelper.RemoveAuthenticationCookie(HttpContext);
            return RedirectToAction("Index");
        }
    }
}