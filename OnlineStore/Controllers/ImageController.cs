using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data;

namespace OnlineStore.Controllers
{
    public class ImageController : Controller
    {
        UnitOfWork unit = new UnitOfWork();
        
        [Route("image/{name}")]
        public IActionResult Get(string name)
        {
            var image = unit.ImageRepository.Get(x => x.Path == name).FirstOrDefault();
            if(image != null)
            {
                var fullpath = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles", image.Path);
                var img = System.IO.File.OpenRead(fullpath);
                return File(img, "image/jpeg");
            }
            return View();
        }
    }
}