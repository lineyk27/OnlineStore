using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.ViewModel;
using OnlineStore.Data;

namespace OnlineStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        UnitOfWork unit = new UnitOfWork();
        [Route("/cart")]
        public IActionResult Index()
        {
            ShoppingCartModel shoppingCart = new ShoppingCartModel();
            shoppingCart.ShoppingCarts = unit.ShoppingCartRepository.Get(x => x.User.Email == User.Identity.Name, includeProperties:"User,Product");
            return View(shoppingCart);
        }
    }
}