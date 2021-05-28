using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPlace.Mappings;
using MyPlace.Models;
using MyPlace.Services.Interfaces;
using MyPlace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IImagesServices _imagesService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ImagesController(IImagesServices imagesService, UserManager<ApplicationUser> userManager)
        {
            _imagesService = imagesService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Overview()
        {
            var user = User;
            var userFromDb = await _userManager.FindByEmailAsync(user.Identity.Name);
            
            var images = _imagesService.GetAllByUserId(userFromDb.Id);

            var viewImages = images.Select(x => x.ToImageViewModel()).ToList();

            return View(viewImages);
        }
        public async Task<IActionResult> Details(int id, string errorMessage)
        {
            var image = _imagesService.GetById(id);
            if(errorMessage != null)
            {
                ViewBag.ErrorMessage = errorMessage;
            }
            

            if (image == null)
            {
                ViewBag.Message = $"There is no image with Id: {id}";
                return View();
            }
            return View(image.ToImageViewModel());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var imageFromDb = _imagesService.GetById(id);
            if (imageFromDb == null)
            {
                return RedirectToAction("Error", "Home", new { ErrorMessage = $"There is no hotel with Id: {id}." });
            }

            var imageForView = imageFromDb.ToImageViewModel();

            return View(imageForView);
        }
        [HttpPost]
        public IActionResult Edit(ImageViewModel imageViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction($"Details/{imageViewModel.Id}", new { ErrorMessage = "There has been a mistake with your input. Please try again." });
            }

            var imageToEdit = imageViewModel.ToModel();

            var response = _imagesService.Update(imageToEdit);

            if (!response.IsSuccessful)
            {
                return RedirectToAction($"Details", new { ErrorMessage = response.Message });
            }

            return RedirectToAction($"Details", new { id = imageViewModel.Id });
        }
        
    }
}
