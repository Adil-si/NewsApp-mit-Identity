using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsApplicationV2.Models;

namespace NewsApplicationV2.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        public AccountController(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel()
            {
                Username = string.Empty,
                Password = string.Empty,
                ReturnUrl = returnUrl
            });

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser? user = await userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(
                    user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(model.ReturnUrl ?? "/");
                    }
                }
                ModelState.AddModelError("", "Username oder Passwort ungültig");
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
        public IActionResult AccessDenied(string returnUrl)
        {
            return View("AccessDenied", returnUrl);
        }


    }
}
