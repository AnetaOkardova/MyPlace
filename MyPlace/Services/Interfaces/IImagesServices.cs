using MyPlace.DtoModels;
using MyPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Services.Interfaces
{
    public interface IImagesServices
    {
        List<Image> GetAllPublicWithFilter(string username);
        List<Image> GetAllByUserId(string id);
        Image GetById(int id);
        StatusModel Update(Image image);
        void Delete(Image image);
        void Create(Image image, string userId);
        bool CouldEdit(int imageId, string userId);
    }
}
