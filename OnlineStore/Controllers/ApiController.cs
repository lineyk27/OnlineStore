using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data;
using OnlineStore.Models.Database;

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
        [Route("api/product/remove/{id}")]
        public IActionResult RemoveProduct(int? id, [FromQuery(Name="redirect")] string redirect)
        {
            var user = unit
                .UserRepository.Get(x => x.Email == User.Identity.Name, includeProperties:"Role")
                .FirstOrDefault();
            if(id != null && User.Identity.IsAuthenticated && user.Role.Name == "Administrator")
            {
                unit.ProductRepository.Delete((int)id);
                unit.Save();
            }
            return Redirect(redirect);
        }
        [Route("api/rate/{id}")]
        public IActionResult AddRate(int? id,[FromQuery(Name="rate")] int? rate, [FromQuery(Name="redirect")] string redirect)
        {
            if(id != null && rate != null)
            {
                var user = unit.UserRepository.Get(x => x.Email == User.Identity.Name).FirstOrDefault();
                var r = unit.RateRepository.Get(x => x.UserId == user.Id && x.ProductId == (int)id).FirstOrDefault();

                if(r != null)
                {
                    r.Score = (int)rate;
                    unit.RateRepository.Update(r);
                    unit.Save();
                }
                else
                {
                    r = new Rate() { UserId = user.Id, ProductId = (int)id, Score = (int)rate };
                    unit.RateRepository.Insert(r);
                    unit.Save();
                }
            }
            return Redirect(redirect);
        }
        [Route("api/rate/remove/{id}")]
        public IActionResult RemoveRate(int? id, [FromQuery(Name="redirect")] string redirect)
        {
            var user = unit.UserRepository.Get(x => x.Email == User.Identity.Name).FirstOrDefault();
            if(user != null && id != null)
            {
                var rate = unit.RateRepository.Get(x => x.UserId == user.Id && x.ProductId == (int)id).FirstOrDefault();
                unit.RateRepository.Delete(rate);
                unit.Save();
            }
            return Redirect(redirect);
        }
        [Route("api/comment/{id}")]
        public IActionResult AddComment(int? id,[FromQuery(Name="comment")]string comment, [FromQuery(Name = "redirect")] string redirect)
        {
            var user = unit.UserRepository.Get(x => x.Email == User.Identity.Name).FirstOrDefault();

            var comm = unit
                .CommentRepository
                .Get(x => x.UserId == user.Id && x.ProductId == (int)id)
                .FirstOrDefault();

            if(comm == null)
            {
                comm = new Comment()
                {
                    UserId = user.Id,
                    ProductId = (int)id,
                    Text = comment
                };
                unit.CommentRepository.Insert(comm);
            }
            else
            {
                comm.Text = comment;
                unit.CommentRepository.Update(comm);
            }
            unit.Save();
            return Redirect(redirect);
        }
        [Route("api/admin/user/{id}")]
        public IActionResult ChangeRole(int? id,[FromQuery(Name="role")] string role, [FromQuery(Name="redirect")] string redirect)
        {
            var user = unit
                .UserRepository
                .Get(x => x.Id == id)
                .FirstOrDefault();

            var admin = unit.UserRoleRepository.Get(x => x.Name == "Administrator").FirstOrDefault().Id;
            var moder = unit.UserRoleRepository.Get(x => x.Name == "Moderator").FirstOrDefault().Id;
            var simple = unit.UserRoleRepository.Get(x => x.Name == "SimpleUser").FirstOrDefault().Id;

            if(user != null)
            {
                if(role == "moderator")
                {
                    user.RoleId = moder;
                }
                else if(role == "admin")
                {
                    user.RoleId = admin;
                }
                else if(role == "simpleuser")
                {
                    user.RoleId = simple;
                }
                unit.UserRepository.Update(user);
                unit.Save();
            }

            return Redirect(redirect);
        }
    }
}