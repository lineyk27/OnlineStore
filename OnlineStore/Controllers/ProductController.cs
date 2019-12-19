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
using Microsoft.AspNetCore.Mvc.Rendering;

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
                var product = unit.ProductRepository.Get(x => x.Id == id, includeProperties: "Image,Rates,Category").FirstOrDefault();
                if (product == null)
                    return RedirectToAction("Index", "Home");

                List<Comment> comments = unit
                    .CommentRepository
                    .Get(x => x.ProductId == product.Id, includeProperties:"User,Product")
                    .ToList();
                bool inpurchase = false;
                bool incart = false;
                bool commented = false;
                bool rated = false;
                if (User.Identity.IsAuthenticated)
                {
                    var purchases = unit
                        .PurchaseProductRepository
                        .Get(x => x.ProductId == product.Id, includeProperties: "Purchase,Product");
                    var user = unit
                        .UserRepository
                        .Get(x => x.Email == User.Identity.Name)
                        .FirstOrDefault();
                    inpurchase = purchases
                        .Where(x => x.Purchase.UserId == user.Id)
                        .Count() != 0;
                    incart = unit
                        .ShoppingCartRepository
                        .Get(x => x.ProductId == product.Id && x.UserId == user.Id && x.Count != 0)
                        .Count() != 0;
                    rated = unit
                        .RateRepository
                        .Get(x => x.UserId == user.Id && x.ProductId == product.Id)
                        .Count() != 0;

                    unit.Save();
                }
                ProductViewModel model = new ProductViewModel()
                {
                    Product = product,
                    InPurchase = inpurchase,
                    InShopingCart = incart,
                    Comments = comments,
                    Commented = commented,
                    Rated = rated
                };
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        [Route("product/edit/{id}")]
        public IActionResult EditProduct(int? id)
        {
            Product product = null;
            if (id != null)
            {
                product = unit
                    .ProductRepository
                    .Get(x => x.Id == id, includeProperties: "Category")
                    .FirstOrDefault();
            }
            ProductEditModel model = new ProductEditModel();

            if (product != null)
            {
                model.Model = product.Model;
                model.Producer = product.Producer;
                model.Price = product.Price;
                model.Id = product.Id;
                model.Description = product.Description;
                var categories = unit.CategoryRepository.Get().ToList();
                var sel = categories.Where(x => x.Id == product.CategoryId).FirstOrDefault();
                var sellist = new SelectList(categories, "Id", "Name", sel);

                var commenabled= (bool)product.CommentsEnabled == true ? "Yes" : "No";

                model.CommentsEnabled = new SelectList(new List<string>() { "Yes", "No" }, commenabled);
                model.Categories = sellist;
            }
            else
            {
                model.Categories = new SelectList(unit.CategoryRepository.Get().ToList(), "Id", "Name");
                model.CommentsEnabled = new SelectList(new List<string>() { "Yes", "No" }, "Yes");
            }

            return View("Edit",model);
        }

        public IActionResult Save(ProductEditModel pmodel)
        {
            Debug.WriteLine("in edit with model");
            
            var user = unit
                .UserRepository.Get(x => x.Email == User.Identity.Name)
                .FirstOrDefault();
            if(user != null)
            {
                Product product = null;
                if (pmodel.Id != 0)
                {
                    product = unit
                        .ProductRepository
                        .Get(x => x.Id == pmodel.Id)
                        .FirstOrDefault();
                }

                var commentsenabled = Request.Form["CommentsEnabled"].ToString();
                var category = int.Parse(Request.Form["Categories"].ToString());
                if (product != null)
                {
                    product.Model = pmodel.Model;
                    product.Producer = pmodel.Producer;
                    product.Price = pmodel.Price;
                    product.Description = pmodel.Description;
                    product.CommentsEnabled= commentsenabled == "Yes" ? true : false;
                    product.CategoryId = category;

                    unit
                        .ProductRepository
                        .Update(product);
                    unit.Save();
                }
                else
                {

                    product = new Product()
                    {
                        Model = pmodel.Model,
                        Producer = pmodel.Producer,
                        Price = pmodel.Price,
                        Description = pmodel.Description,
                        CommentsEnabled = commentsenabled == "Yes" ? true : false,
                        CategoryId = category,
                        CreatorUserId=user.Id,
                        CreationTime=DateTime.Now,
                        ImageId=7
                    };
                    unit
                        .ProductRepository
                        .Insert(product);
                    unit.Save();
                }

                return View("Edit", pmodel);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}