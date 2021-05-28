using MyPlace.Models;
using MyPlace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Mappings
{
    public static class DomainModelsExtensions
    {
        public static ImageViewModel ToImageViewModel(this Image entity)
        {
            return new ImageViewModel()
            {
                Id = entity.Id,
                ImageUrl = entity.ImageUrl,
                IsPrivate = entity.IsPrivate,
                DateCreated = entity.DateCreated,
                Username = entity.User.UserName
            };
        }
    }
}
