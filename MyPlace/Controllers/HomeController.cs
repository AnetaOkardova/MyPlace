using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyPlace.Mappings;
using MyPlace.Models;
using MyPlace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Controllers
{
    public class HomeController : Controller
    {
        private readonly IImagesServices _imagesService;

        public HomeController(IImagesServices imagesService)
        {
            _imagesService = imagesService;
        }
        public IActionResult Overview(string userNameSearch)
        {
           var allPublicImages =  _imagesService.GetAllPublicWithFilter(userNameSearch);
            if (allPublicImages == null)
            {
                ViewBag.Message = "There are no images to show";
            }
            var viewImages = allPublicImages.Select(x => x.ToImageViewModel()).ToList();

            return View(viewImages);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
