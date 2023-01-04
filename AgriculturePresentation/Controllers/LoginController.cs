using AgricultureUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureUI.Controllers
{
    [AllowAnonymous] //to be exempt from Authorization
    public class LoginController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _sigInManager;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _sigInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
		{
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> Index(SignViewModel signViewModel)
        {
            if (ModelState.IsValid)
            {
                var result= await _sigInManager.PasswordSignInAsync(signViewModel.username,signViewModel.password,false,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel registerViewModel) //to do the job of registering with process Authentiaciton
        {
            IdentityUser identityUser = new IdentityUser()
            {
                Id = "2",
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Mail
            };
            if (registerViewModel.Password==registerViewModel.PasswordConfirmation)
            {
                var result = await _userManager.CreateAsync(identityUser, registerViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(registerViewModel);
        }
    }
}
