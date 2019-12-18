using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.ViewModel;
using System.Diagnostics;
using OnlineStore.Data;

namespace OnlineStore.Controllers
{
    public class FilterController : Controller
    {
        UnitOfWork unit = new UnitOfWork();
        //[Route("filter")]
        public IActionResult Index(int? category, string name, int page = 1, SortState sortOrder= SortState.NameAsc)
        {
            int pageSize = 2;
            var products = unit.ProductRepository.Get(includeProperties: "Image,Rates,Category").AsQueryable();
            if(category != null)
            {
                products = products.Where(x => x.Category.Id == category);
            }
            if(!String.IsNullOrEmpty(name))
            {
                products = products.Where(x => (x.Producer + x.Model).Contains(name));
            }
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    products = products.OrderByDescending(x => x.Producer + x.Model);
                    break;
                case SortState.PriceAsc:
                    products = products.OrderBy(x => x.Price);
                    break;
                case SortState.PriceDesc:
                    products = products.OrderByDescending(x => x.Price);
                    break;
                case SortState.CategoryAsc:
                    products = products.OrderBy(x => x.Category.Name);
                    break;
                case SortState.CategoryDesc:
                    products = products.OrderByDescending(x => x.Category.Name);
                    break;
                case SortState.RateAsc:
                    products = products.OrderBy(x => x.Rates.Sum(r => r.Score));
                    break;
                case SortState.RateDesc:
                    products = products.OrderByDescending(x => x.AverageRate);
                    break;
                default:
                    products = products.OrderBy(x => x.Producer + x.Model);
                    break;
            }

            var count = products.Count();
            var items = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            IndexViewModel model = new IndexViewModel()
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(unit.CategoryRepository.Get().ToList(), category, name),
                Products = items
            };

            return View(model);
        }
    }
}