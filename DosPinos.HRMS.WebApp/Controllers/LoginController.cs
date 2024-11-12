using DosPinos.HRMS.Controllers.Securities.Catalogs;
using DosPinos.HRMS.Entities.DTOs.Securities;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Interfaces.Securities;
using DosPinos.HRMS.WebApp.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DosPinos.HRMS.WebApp.Controllers
{
    public class LoginController(UserController userController) : Controller
    {
        private readonly UserController _userController = userController;

        public IActionResult Index() =>
            User.Identity.IsAuthenticated ? Redirect("~/Home/Index") : View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserDTO userDTO)
        {
            if (User.Identity.IsAuthenticated) Redirect("~/Home/Index");

            userDTO.UserId = 1;
            var response = await _userController.ProcessAsync(userDTO);

            if (response.Status != ResponseStatus.Success)
            {
                ViewData["alert"] = response;
                return View("Index");
            }

            await CookiesHelper.CreateAuthenticationCookies(HttpContext, (ILoginUserDTO)response.Content);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await CookiesHelper.RemoveAuthenticationCookie(HttpContext);
            return RedirectToAction("Login");
        }
    }
}