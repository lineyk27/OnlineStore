using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data;
using OnlineStore.Models.Database;
using System.Diagnostics;

namespace OnlineStore.Controllers
{
    public class ApiController : Controller
    {
        UnitOfWork unit = new UnitOfWork();
        [Route("api/cart/add/{id}")]
        public IActionResult AddToShop(int id, [FromQuery(Name="count")]int? count,[FromQuery(Name = "redirect")]string redirect)
        {
            var user = unit.UserRepository.Get(x => x.Email == User.Identity.Name).FirstOrDefault();
            var product = unit.ProductRepository.Get(x => x.Id == id).FirstOrDefault();
            count = count ?? 1;
            if(user != null)
            {
                if(product != null)
                {
                    var cart = unit
                        .ShoppingCartRepository
                        .Get(x => x.ProductId == product.Id && x.UserId == user.Id)
                        .FirstOrDefault();
                    if(cart != null)
                    {
                        count = count ?? cart.Count;
                        cart.Count = (int)count;
                        unit
                            .ShoppingCartRepository
                            .Update(cart);
                        unit.Save();
                        Debug.WriteLine(count);
                    }
                    else
                    {
                        cart = new ShoppingCart() 
                        { 
                            UserId = user.Id, 
                            ProductId = product.Id, 
                            Count = (int)count
                        };
                        unit
                            .ShoppingCartRepository
                            .Insert(cart);
                        unit.Save();
                    };
                    if (redirect != null)
                        return Redirect(redirect);
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Route("api/cart/remove/{id}")]
        public IActionResult RemoveFromShop(int? id, [FromQuery(Name = "redirect")]string redirect)
        {
            Debug.WriteLine("In api ermove");
            ShoppingCart cart = unit.ShoppingCartRepository.Get(x => x.User.Email == User.Identity.Name && x.ProductId == id, includeProperties: "User").FirstOrDefault();
            if(cart != null)
            {
                unit.ShoppingCartRepository.Delete(cart);
                unit.Save();
            }
            if (redirect != null)
                return Redirect(redirect);
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult AddComment(string user, [FromQuery(Name = "redirect")]string redirect)
        {

            return Redirect(redirect);
        }
    }
}