using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data;
using OnlineStore.Models.Database;
using OnlineStore.Models.ViewModel;

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

            string adress = purchase.Surname +
                " " + purchase.Name +
                " " + purchase.City +
                " " + purchase.Street +
                " " + purchase.House +
                " " + purchase.Apartment +
                " " + purchase.Offices.SelectedValue +
                " " + purchase.Options.SelectedValue;

            var user = unit.UserRepository.Get(x => x.Email == User.Identity.Name).FirstOrDefault();

            Purchase np = new Purchase()
            {
                UserId=user.Id,
                Adress=adress,
                FullPrice=purchase.TotalCost,
                CreationTime=DateTime.Now
            };
            var time = np.CreationTime;
            unit.PurchaseRepository.Insert(np);
            unit.Save();
            np = unit.PurchaseRepository.Get(x => x.CreationTime == time).FirstOrDefault();
            var carts = unit.ShoppingCartRepository.Get(x => x.UserId == user.Id, includeProperties:"Product");
            decimal total = carts.Sum(x => x.Product.Price * x.Count);
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

            var succes = new SuccesViewModel() { TotalPrice = total };
            return View("Success", succes);
        }
    }
}