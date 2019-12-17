using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using OnlineStore.Data;
using OnlineStore.Models;
using OnlineStore.Models.ViewModel;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        UnitOfWork unit = new UnitOfWork();
        [Route("Product/{id}")]
        public IActionResult Index(int? id)
        {
            if(id != null)
            {
                var product = unit.ProductRepository.Get(x => x.Id == id, includeProperties: "Image,Comments,Rates,Category").FirstOrDefault();
                if(product != null)
                {
                    double score = 0;
                    if(product.Rates.Count != 0)
                        score = product.Rates.Sum(x => x.Score)/ product.Rates.Count;
                    ProductModel model = new ProductModel()
                    {
                        Id=product.Id,
                        Producer=product.Producer,
                        Model=product.Model,
                        Description=product.Description,
                        Category=product.Category.Name,
                        Price=product.Price,
                        Score=score,
                        Comments=product.Comments,
                        ImageName=product.Image.Path
                    };

                    var cart = unit.ShoppingCartRepository.Get(x => x.User.Email == User.Identity.Name && x.Product.Id == product.Id, includeProperties: "Product,User").FirstOrDefault();
                    bool isInCart = false;
                    if (cart != null)
                    {
                        isInCart = true;
                    }

                    ViewData["InCart"] = isInCart;
                    return View(model);
                }
                else
                {
                    return StatusCode(404);
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}