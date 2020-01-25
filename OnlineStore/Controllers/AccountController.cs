using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.ViewModel;
using OnlineStore.Models.Database;
using OnlineStore.Services;
using OnlineStore.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

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
                    user = new User 
                    {
                        Name=model.Name, 
                        Surname=model.Surname, 
                        Email = model.Email, 
                        PasswordHash = PasswordConverter.Hash(model.Password),
                        CreationTime = DateTime.Now
                    };
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
        public IActionResult Purchases()
        {
            return View();
        
        }
        [Route("account/info")]
        public IActionResult Info()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = unit
                    .UserRepository
                    .Get(x => x.Email == User.Identity.Name,includeProperties:"Role")
                    .FirstOrDefault();
                bool isModer = false;
                bool isAdmin= false;
                if(user.Role.Name == "Administrator")
                {
                    isAdmin = true;
                }
                if(user.Role.Name == "Moderator")
                {
                    isModer = true;
                }

                AccountInfoViewModel model = new AccountInfoViewModel()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    CreationTime = user.CreationTime,
                    IsModerator = isModer,
                    IsAdmin=isAdmin
                };

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Authorize]
        public IActionResult UserPurchases()
        {
            var email = User.Identity.Name;
            var user = unit
                .UserRepository
                .Get(x => x.Email == email)
                .FirstOrDefault();
            var purchases = unit
                .PurchaseRepository
                .Get(x => x.UserId == user.Id, includeProperties: "PurchaseProducts.Product")
                .OrderByDescending(x => x.CreationTime);
            var model = new UserPurchasesViewModel()
            {
                Purchases = purchases
            };
            return View(model);
        }

    }
}