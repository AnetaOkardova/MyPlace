using MyPlace.Models;
using MyPlace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Mappings
{
    public static class ViewModelsExtensions
    {
        public static Image ToModel(this ImageViewModel entity)
        {
            return new Image()
            {
                Id = entity.Id,
                ImageUrl = entity.ImageUrl,
                IsPrivate = entity.IsPrivate,
                DateCreated = entity.DateCreated
            };
        }
        public static Image ToModel(this CreateImageViewModel entity)
        {
            return new Image()
            {
                ImageUrl = entity.ImageUrl,
                IsPrivate = entity.IsPrivate,
            };
        }
        
    }
}
