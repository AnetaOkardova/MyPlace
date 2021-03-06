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
            var query = _context.Images.Include(x => x.User).Where(x => x.IsPrivate == false).AsQueryable();
            if (username != null)
            {
                query = query.Where(x => x.User.UserName.Contains(username));
            }

            var images = query.ToList();
            return images;
        }

        public List<Image> GetAllByUserId(string id)
        {
           return _context.Images.Include(x=>x.User).Where(x=>x.UserId == id).ToList();
        }

        public Image GetById(int id)
        {
            return _context.Images.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public void Update(Image image)
        {
            _context.Images.Update(image);
            _context.SaveChanges();
        }

        public void Delete(Image image)
        {
            _context.Images.Remove(image);
            _context.SaveChanges();
        }

        public void Create(Image image)
        {
            _context.Images.Add(image);
            _context.SaveChanges();
        }

        public bool CouldEdit(int imageId, string userId)
        {
            var image = _context.Images.Include(x=>x.User).FirstOrDefault(x=>x.Id == imageId && x.UserId == userId) ;
            if(image == null)
            {
                return false;
            }
            return true;
        }
    }
}
