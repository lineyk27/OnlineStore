using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineStore.Models.Database;
using OnlineStore.Models;
using OnlineStore.Data;
using OnlineStore.Models.ViewModel;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        UnitOfWork unit = new UnitOfWork();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Index([FromQuery(Name="page")]int page,
                                    [FromQuery(Name = "sort")]string sort,
                                    [FromQuery(Name = "filter")]string filter)
        {
            ViewData["Categories"] = unit.CategoryRepository.Get();
            var products =  unit.ProductRepository.Get(includeProperties: "Image,Comments,Rates,Category");
            ViewData["prod"] = products;
            return View(products);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
