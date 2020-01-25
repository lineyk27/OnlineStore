using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data;
using OnlineStore.Models.ViewModel;
using OnlineStore.Models.Database;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        UnitOfWork unit = new UnitOfWork();
        public async Task SaveImage(IFormFile file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles", file.FileName);
            await file.CopyToAsync(new FileStream(path, FileMode.Create));
        }
        [Route("Product/{id}")]
        public IActionResult Index(int? id)
        {
            if (id != null)
            {
                var product = unit.ProductRepository.Get(x => x.Id == id, includeProperties: "Image,Rates,Category").FirstOrDefault();
                if (product == null)
                    return RedirectToAction("Index", "Home");

                List<Comment> comments = unit
                    .CommentRepository
                    .Get(x => x.ProductId == product.Id, includeProperties: "User,Product")
                    .ToList();
                bool inpurchase = false;
                bool incart = false;
                bool commented = false;
                bool rated = false;
                bool canEditComments = false;
                bool canEditProduct = false;
                if (User.Identity.IsAuthenticated)
                {
                    var purchases = unit
                        .PurchaseProductRepository
                        .Get(x => x.ProductId == product.Id, includeProperties: "Purchase,Product");
                    var user = unit
                        .UserRepository
                        .Get(x => x.Email == User.Identity.Name, includeProperties: "Role")
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
                    canEditComments = user.Role.Name == "Administrator" || user.Role.Name == "Moderator";
                    canEditProduct = user.Role.Name == "Administrator";
                    unit.Save();
                }
                ProductViewModel model = new ProductViewModel()
                {
                    Product = product,
                    InPurchase = inpurchase,
                    InShopingCart = incart,
                    Comments = comments,
                    Commented = commented,
                    Rated = rated,
                    CanEditComments = canEditComments,
                    CanEditProduct = canEditProduct
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
                    .Get(x => x.Id == id, includeProperties: "Category,Image")
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
                model.ImageName = product.Image?.Path;

                var categories = unit.CategoryRepository.Get().ToList();
                var sel = categories.Where(x => x.Id == product.CategoryId).FirstOrDefault();
                var sellist = new SelectList(categories, "Id", "Name", sel);

                var commenabled = product.CommentsEnabled == true ? "Yes" : "No";

                model.CommentsEnabled = new SelectList(new List<string>() { "Yes", "No" }, commenabled);
                model.Categories = sellist;
            }
            else
            {
                model.Categories = new SelectList(unit.CategoryRepository.Get().ToList(), "Id", "Name");
                model.CommentsEnabled = new SelectList(new List<string>() { "Yes", "No" }, "Yes");
            }

            return View("Edit", model);
        }

        public async Task<IActionResult> SaveAsync(ProductEditModel edit)
        {

            var user = unit
                .UserRepository.Get(x => x.Email == User.Identity.Name)
                .FirstOrDefault();
            if (user != null)
            {
                Product product = null;
                if (edit.Id != 0)
                {
                    product = unit
                        .ProductRepository
                        .Get(x => x.Id == edit.Id)
                        .FirstOrDefault();
                }

                var commentsenabled = Request.Form["CommentsEnabled"].ToString();
                var category = int.Parse(Request.Form["Categories"].ToString());
                if (product != null)
                {
                    if (edit.Image != null)
                    {
                        unit.ImageRepository.Insert(new Image() { Path = edit.Image.FileName });
                        unit.Save();
                        product.ImageId = unit.ImageRepository.Get(x => x.Path == edit.Image.FileName).FirstOrDefault().Id;
                    }
                    product.Model = edit.Model;
                    product.Producer = edit.Producer;
                    product.Price = edit.Price;
                    product.Description = edit.Description;
                    product.CommentsEnabled = commentsenabled == "Yes" ? true : false;
                    product.CategoryId = category;

                    unit
                        .ProductRepository
                        .Update(product);
                    unit.Save();
                }
                else
                {
                    int id = 7;
                    if (edit.Image != null)
                    {
                        //edit.Image = edit.Image;

                        await SaveImage(edit.Image);
                        unit.ImageRepository.Insert(new Image() { Path = edit.Image.FileName });
                        unit.Save();
                        id = unit.ImageRepository.Get(x => x.Path == edit.Image.FileName).FirstOrDefault().Id;
                    }
                    product = new Product()
                    {
                        Model = edit.Model,
                        Producer = edit.Producer,
                        Price = edit.Price,
                        Description = edit.Description,
                        CommentsEnabled = commentsenabled == "Yes" ? true : false,
                        CategoryId = category,
                        CreatorUserId = user.Id,
                        CreationTime = DateTime.Now,
                        ImageId = id
                    };

                    unit
                        .ProductRepository
                        .Insert(product);
                    unit.Save();
                }

                return Redirect("/admin/products");
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult EditComment([FromQuery]int productId, [FromQuery]int userId)
        {
            var comment = unit
                .CommentRepository
                .Get(x => x.ProductId == productId && x.UserId == userId, includeProperties: "Product")
                .FirstOrDefault();
            if (comment == null)
                return RedirectToAction("Index", "Home");
            var model = new CommentModel()
            {
                UserId = comment.UserId,
                Text = comment.Text,
                ProductId = comment.ProductId
            };

            return View(model);
        }
        public IActionResult SaveComment([FromForm]CommentModel model)
        {
            Debug.WriteLine($"{model.UserId} {model.ProductId} ");
            var comment = unit
                .CommentRepository
                .Get(x => x.ProductId == model.ProductId && x.UserId == model.UserId)
                .FirstOrDefault();
            if (comment == null)
                return RedirectToAction("Index", "Home");

            comment.Text = model.Text;
            unit.CommentRepository.Update(comment);
            unit.Save();
            return Redirect($"/product/{comment.ProductId}");
        }
        public IActionResult RemoveComment(int productId, int userId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = unit
                    .UserRepository
                    .Get(x => x.Email == User.Identity.Name, includeProperties: "Role")
                    .FirstOrDefault();
                if (user.Role.Name == "Administrator" || user.Role.Name == "Moderator")
                {
                    var comment = unit
                        .CommentRepository
                        .Get(x => x.UserId == userId && x.ProductId == productId)
                        .FirstOrDefault();

                    var prodId = comment.ProductId;
                    unit.CommentRepository.Delete(comment);
                    unit.Save();
                    return Redirect($"/product/{prodId}");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}