using Microsoft.AspNetCore.Mvc;
using riode_backend.Helpers.Enums;
using riode_backend.Helpers;
using riode_backend.ViewModels;
using Microsoft.AspNetCore.Identity;
using riode_backend.Models;

namespace riode_backend.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser appUser = new AppUser()
            {
                Fullname = model.UserName,
                Email = model.Email,
                UserName = model.UserName,
                IsActive = true
            };

            IdentityResult identityResult = await _userManager.CreateAsync(appUser, model.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

            string link = Url.Action("ConfirmEmail", "Auth", new { email = appUser.Email, token }, HttpContext.Request.Scheme, HttpContext.Request.Host.Value);

            string body = $"<a href='{link}'>Confirm your email</a>";

            EmailHelper emailHelper = new EmailHelper(_configuration);
            await emailHelper.SendEmailAsync(new MailRequest { ToEmail = appUser.Email, Subject = "Confirm Email", Body = body });

            //await _userManager.AddToRoleAsync(appUser, Roles.User.ToString());
            await _userManager.AddToRoleAsync(appUser, Roles.Moderator.ToString());
            //await _userManager.AddToRoleAsync(appUser, Roles.Admin.ToString());

            return RedirectToAction("Login", "Auth");
        }
    }
}
