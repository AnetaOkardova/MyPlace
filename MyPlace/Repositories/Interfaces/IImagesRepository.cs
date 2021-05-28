using MyPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Repositories.Interfaces
{
    public interface IImagesRepository
    {
        List<Image> GetAllPublicWithFilter(string username);
        List<Image> GetAllByUserId(string id);
        Image GetById(int id);
        void Update(Image image);
    }
}
