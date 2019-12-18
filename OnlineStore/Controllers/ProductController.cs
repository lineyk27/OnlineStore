using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using OnlineStore.Data;
using OnlineStore.Models;
using OnlineStore.Models.ViewModel;
using OnlineStore.Models.Database;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        UnitOfWork unit = new UnitOfWork();
        [Route("Product/{id}")]
        public IActionResult Index(int? id, string Comment)
        {
            if(id != null)
            {
                var product = unit.ProductRepository.Get(x => x.Id == id, includeProperties: "Image,Rates,Category").FirstOrDefault();
                if (product == null)
                    return RedirectToAction("Index", "Home");

                List<Comment> comments = unit.CommentRepository.Get(x => x.ProductId == product.Id, includeProperties:"User,Product").ToList();
                bool inpurchase = false;
                bool incart = false;
                if (User.Identity.IsAuthenticated)
                {
                    var purchases = unit.PurchaseProductRepository.Get(x => x.ProductId == product.Id, includeProperties: "Purchase,Product");
                    var user = unit.UserRepository.Get(x => x.Email == User.Identity.Name).FirstOrDefault();
                    inpurchase = purchases.Where(x => x.Purchase.UserId == user.Id).Count() != 0;
                    incart = unit.ShoppingCartRepository.Get(x => x.ProductId == product.Id && x.UserId == user.Id && x.Count != 0).Count() != 0;

                    if (Comment != null && inpurchase == true)
                    {
                        unit.CommentRepository.Insert(new Comment()
                        {
                            Text = Comment,
                            UserId = user.Id,
                            ProductId=product.Id
                        });
                    }
                }
                ProductViewModel model = new ProductViewModel()
                {
                    Product = product,
                    InPurchase = inpurchase,
                    InShopingCart = incart,
                    Comments = comments
                };

                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}