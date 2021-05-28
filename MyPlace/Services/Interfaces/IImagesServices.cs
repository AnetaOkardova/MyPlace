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
    }
}
