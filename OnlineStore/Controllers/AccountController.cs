using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.ViewModel;
using OnlineStore.Models.Database;
using OnlineStore.Services;
using OnlineStore.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

enum UserClaim
{
    Name=0,
    Surname=1,
    Email=2,
    Role=3
}
namespace OnlineStore.Controllers
{
    public class AccountController : Controller
    {
        UnitOfWork unit = new UnitOfWork();
        [HttpPost]
        private async Task Authenticate(User user)
        {
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
                };
                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            }
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = unit.UserRepository.Get(x => x.Email == model.Email && x.PasswordHash == PasswordConverter.Hash(model.Password), includeProperties:"Role").FirstOrDefault();
                if (user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Uncorrect email or password input");
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }
        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = unit.UserRepository.Get(x => x.Email == model.Email).FirstOrDefault();
                if (user == null)
                {
                    user = new User { Email = model.Email, PasswordHash = PasswordConverter.Hash(model.Password) };
                    UserRole userRole = unit.UserRoleRepository.Get(x => x.Name == "SimpleUser").FirstOrDefault();
                    if (userRole != null)
                        user.Role = userRole;

                    unit.UserRepository.Insert(user);
                    unit.Save();
                    await Authenticate(user); 
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "The same account already exist");
            }
            return View(model);
        }
    }
}