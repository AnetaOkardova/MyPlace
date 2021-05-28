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
        public List<Image> GetAllPublicWithFilter(string username)
        {
            return _imagesRepository.GetAllPublicWithFilter(username);
        }
    }
}
