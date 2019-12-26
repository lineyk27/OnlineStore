using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.ViewModel;
using OnlineStore.Data;
using System.Linq;

namespace OnlineStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        UnitOfWork unit = new UnitOfWork();
        [Route("/cart")]
        public IActionResult Index(int? id, int? count, int? deleted)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (deleted != null && deleted != -1)
                {
                    var del = unit
                        .ShoppingCartRepository
                        .Get(x => x.ProductId == deleted && x.User.Email == User.Identity.Name, includeProperties:"User")
                        .FirstOrDefault();
                    unit.ShoppingCartRepository.Delete(del);
                    unit.Save();
                }
                if (id != null && count != null)
                {
                    var cart = unit
                        .ShoppingCartRepository
                        .Get(x => x.ProductId == id && x.User.Email == User.Identity.Name)
                        .FirstOrDefault();
                    if (cart != null)
                    {
                        cart.Count = (int)count;
                        unit.ShoppingCartRepository.Update(cart);
                    }
                }
                var carts = unit
                    .ShoppingCartRepository
                    .Get(x => x.User.Email == User.Identity.Name, includeProperties: "User,Product")
                    .ToList();
                decimal total = carts.Sum(x => x.Product.Price * x.Count);
                ShoppingCartModel model = new ShoppingCartModel() 
                { 
                    ShoppingCarts=carts,
                    TotalPrice=total
                };
                return View(model);
            }
            return RedirectToActionPermanent("Index","Home");
        }
    }
}