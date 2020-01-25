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
        public SelectList Offices { get; set; }
        public SelectList Options{ get; set; }
        public string OptionName { get; set; }
        public string OfficeName { get; set; }
        public PurchaseViewModel()
        {
            var postOffices = new List<string>() { "New Post", "Meest", "UkrPost" };
            var deliveryOptions = new List<string>() { "On home", "In post office"};

            Offices = new SelectList(postOffices);
            Options = new SelectList(deliveryOptions);
        }
    }
}
