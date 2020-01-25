using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data;
using OnlineStore.Models.Database;
using OnlineStore.Models.ViewModel;
using System.Globalization;
using System.Diagnostics;

namespace OnlineStore.Controllers
{
    public static class DictSerialize
    {
        public static string SerializeJson(this Dictionary<string, int> dict)
        {
            string result = "{";
            for (int i = 0; i < dict.Keys.Count-1; i++)
            {
                string key = dict.Keys.ToList()[i];
                int value = dict[key];
                result += String.Format($"\"{key}\": \"{value}\",");
            };
            result += dict[dict.Keys.ToList().Last()];
            return result + "}";
        }
    }

    public class PurchaseController : Controller
    {
        UnitOfWork unit = new UnitOfWork();
        [Route("purchase")]
        public IActionResult Index()
        {
            var user = unit
                .UserRepository
                .Get(x => x.Email == User.Identity.Name)
                .FirstOrDefault();
            
            var carts = unit
                .ShoppingCartRepository
                .Get(x => x.UserId == user.Id, includeProperties:"Product")
                .ToList();
            
            decimal total = carts.Sum(x => x.Product.Price * x.Count);
            PurchaseViewModel model = new PurchaseViewModel()
            {
                Cart = carts,
                TotalCost = total,
                Name = user.Name,
                Surname = user.Surname
            };

            return View(model);
        }
        public IActionResult Make(PurchaseViewModel purchase)
        {
            purchase.Surname = purchase.Surname ?? " ";
            purchase.Name = purchase.Name ?? " ";
            purchase.City = purchase.City ?? " ";
            purchase.Street = purchase.Street ?? " ";
            purchase.House = purchase.House ?? " ";
            purchase.Apartment = purchase.Apartment ?? " ";

            var office = Request.Form["offices"];
            var delivery = Request.Form["options"];

            string adress = purchase.Surname +
                " " + purchase.Name +
                " " + purchase.City +
                " " + purchase.Street +
                " " + purchase.House +
                " " + purchase.Apartment +
                " " + office +
                " " + delivery;


            var costOffice = 0;
            if (office == "Meest")
                costOffice = 20;
            else if (office == "New Post")
                costOffice = 35;
            else
                costOffice = 15;

            var deliveryCost = delivery == "On home" ? 10 : 0;
            var user = unit.UserRepository.Get(x => x.Email == User.Identity.Name).FirstOrDefault();

            var carts = unit.ShoppingCartRepository.Get(x => x.UserId == user.Id, includeProperties: "Product");
            decimal total = carts.Sum(x => x.Product.Price * x.Count);
            total += (costOffice + deliveryCost); 
            Purchase np = new Purchase()
            {
                UserId=user.Id,
                Adress=adress,
                FullPrice=total,
                CreationTime=DateTime.Now
            };
            var time = np.CreationTime;
            unit.PurchaseRepository.Insert(np);
            unit.Save();
            foreach (var i in carts)
            {
                var npr = new PurchaseProduct() 
                { 
                    PurchaseId=np.Id, 
                    ProductId=i.ProductId, 
                    Count=i.Count
                };
                unit.PurchaseProductRepository.Insert(npr);
                unit
                    .ShoppingCartRepository
                    .Delete(i);
                unit.Save();
            }
            unit.Save();
            var succes = new SuccesViewModel() { TotalPrice = total };
            return View("Success", succes);
        }
    }
}