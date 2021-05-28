using Microsoft.EntityFrameworkCore;
using MyPlace.Data;
using MyPlace.Models;
using MyPlace.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        private ApplicationDbContext _context { get; set; }
        public ImagesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Image> GetAllPublicWithFilter(string username)
        {
            //return _context.Images.Include(x=>x.User).Where(x => x.IsPrivate == true).ToList();

            var query = _context.Images.Include(x => x.User).Where(x => x.IsPrivate == true).AsQueryable();
            if (username != null)
            {
                query = query.Where(x => x.User.UserName.Contains(username));
            }

            var images = query.ToList();
            return images;
        }
    }
}
