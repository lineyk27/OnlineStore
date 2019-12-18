using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using OnlineStore.Models.Database;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace OnlineStore.Models.ViewModel
{
    public class PurchaseViewModel
    {
        public List<ShoppingCart> Cart { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname{ get; set; }
        public decimal TotalCost { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string House { get; set; }
        [Required]
        public string Apartment { get; set; }
        public Dictionary<string, int> PostOffices { get; set; }
        public Dictionary<string, int> DeliveryOptions{ get; set; }
        public SelectList Offices { get; set; }
        public SelectList Options{ get; set; }
        public PurchaseViewModel()
        {
            PostOffices = new Dictionary<string, int>();
            PostOffices["New Post"] = 35;
            PostOffices["Meest"] = 20;
            PostOffices["UkrPost"] = 15;

            DeliveryOptions = new Dictionary<string, int>();
            DeliveryOptions["On home"] = 10;
            DeliveryOptions["In post office"] = 0;

            Offices = new SelectList(PostOffices.Keys.ToList());
            Options = new SelectList(DeliveryOptions.Keys.ToList());

        }
    }
}
