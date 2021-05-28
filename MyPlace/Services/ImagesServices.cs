using MyPlace.DtoModels;
using MyPlace.Models;
using MyPlace.Repositories.Interfaces;
using MyPlace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Services
{
    public class ImagesServices : IImagesServices
    {
        private readonly IImagesRepository _imagesRepository;

        public ImagesServices(IImagesRepository imagesRepository)
        {
            _imagesRepository = imagesRepository;
        }

        public void Create(Image image, string userId)
        {
            image.DateCreated = DateTime.Now;
            image.DateModified = DateTime.Now;
            image.UserId = userId;
            _imagesRepository.Create(image);
        }

        public void Delete(Image image)
        {
            _imagesRepository.Delete(image);
        }

        public List<Image> GetAllByUserId(string id)
        {
            return _imagesRepository.GetAllByUserId(id);
        }

        public List<Image> GetAllPublicWithFilter(string username)
        {
            return _imagesRepository.GetAllPublicWithFilter(username);
        }

        public Image GetById(int id)
        {
            return _imagesRepository.GetById(id);
        }

        public StatusModel Update(Image image)
        {
            var response = new StatusModel();
            var imageFromDB = _imagesRepository.GetById(image.Id);
            if(imageFromDB == null)
            {
                response.IsSuccessful = false;
                response.Message = $"There is no image with id {image.Id}.";
            }
            else
            {
                imageFromDB.ImageUrl = image.ImageUrl;
                imageFromDB.IsPrivate = image.IsPrivate;
                imageFromDB.DateModified = image.DateModified;

                _imagesRepository.Update(imageFromDB);
            }
            return response;
        }
    }
}
