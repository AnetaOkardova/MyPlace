using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Overview(string errorMessage, string successMessage)
        {
            if (errorMessage != null)
            {
                ViewBag.ErrorMessage = errorMessage;
            }
            if (successMessage != null)
            {
                ViewBag.SuccessMessage = successMessage;
            }
            var user = User;
            var userFromDb = await _userManager.FindByEmailAsync(user.Identity.Name);
            
            var images = _imagesService.GetAllByUserId(userFromDb.Id);

            var viewImages = images.Select(x => x.ToImageViewModel()).ToList();

            return View(viewImages);
        }
        public async Task<IActionResult> Details(int id, string errorMessage, string successMessage)
        {
            var image = _imagesService.GetById(id);
            if(errorMessage != null)
            {
                ViewBag.ErrorMessage = errorMessage;
            }
            if (successMessage != null)
            {
                ViewBag.SuccessMessage = successMessage;
            }

            if (image == null)
            {
                ViewBag.Message = $"There is no image with Id: {id}";
                return View();
            }
            return View(image.ToImageViewModel());
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var imageFromDb = _imagesService.GetById(id);
            if (imageFromDb == null)
            {
                return RedirectToAction("Overview", "Home", new { ErrorMessage = $"There is no hotel with Id: {id}." });
            }

            var user = User;
            var userFromDb = await _userManager.FindByEmailAsync(user.Identity.Name);

            var isAllowedToEdit = _imagesService.CouldEdit(imageFromDb.Id, userFromDb.Id);
            if (!isAllowedToEdit)
            {
                return RedirectToAction("Overview", "Home", new { ErrorMessage = "You have no authorization to edit this image." });
            }

            

            var imageForView = imageFromDb.ToImageViewModel();

            return View(imageForView);
        }
        [Authorize]
        [HttpPost]
        public  IActionResult Edit(ImageViewModel imageViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction($"Details/{imageViewModel.Id}", new { ErrorMessage = "There has been a mistake with your input. Please try again." });
            }

            var imageToEdit = imageViewModel.ToModel();

            var response = _imagesService.Update(imageToEdit);

            if (!response.IsSuccessful)
            {
                return RedirectToAction($"Details/{imageViewModel.Id}", new { ErrorMessage = response.Message });
            }

            return RedirectToAction($"Details", new { id = imageViewModel.Id });
        }
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var imageFromDb = _imagesService.GetById(id);
            if (imageFromDb == null)
            {
                return RedirectToAction("Overview", new { ErrorMessage = $"There is no hotel with Id: {id}." });
            }

            var user = User;
            var userFromDb = await _userManager.FindByEmailAsync(user.Identity.Name);

            var isAllowedToEdit = _imagesService.CouldEdit(imageFromDb.Id, userFromDb.Id);
            if (!isAllowedToEdit)
            {
                return RedirectToAction("Overview", "Home", new { ErrorMessage = "You have no authorization to delete this image." });
            }

            _imagesService.Delete(imageFromDb);

            return RedirectToAction("Overview");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateImageViewModel createImageViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction($"Overview", new { ErrorMessage = "There has been a mistake with your input. Please try again." });
            }
            var user = User;
            var userFromDb = await _userManager.FindByEmailAsync(user.Identity.Name);

            _imagesService.Create(createImageViewModel.ToModel(), userFromDb.Id);
            return RedirectToAction("Overview", new { SuccessMessage = "The image has been successfylly created"});
        }
    }
}
