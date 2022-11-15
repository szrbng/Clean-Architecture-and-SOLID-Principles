using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR.LeaveManagement.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAuthenticationService _authService;

        public UsersController(IAuthenticationService authService)
        {
            this._authService = authService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                returnUrl ??= Url.Content("~/");
                var isLoggedIn = await _authService.Authenticate(login.Email, login.Password);
                if (isLoggedIn)
                    return LocalRedirect(returnUrl);
            }
            ModelState.AddModelError("", "Log In Attempt Failed. Please try again.");
            return View(login);
        }

        public IActionResult Register(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registration)
        {
            if (ModelState.IsValid)
            {
                var returnUrl = Url.Content("~/");
                var isCreated = await _authService.Register(registration);
                if (isCreated)
                    return LocalRedirect(returnUrl);
            }

            ModelState.AddModelError("", "Registration Attempt Failed. Please try again.");
            return View(registration);
        }


        public async Task<IActionResult> LogOut(string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            await _authService.Logout();
            return LocalRedirect(returnUrl);
        }


    }
}

