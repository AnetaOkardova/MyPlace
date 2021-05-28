using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.ViewModels
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public bool IsPrivate { get; set; }
        [Required]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        public string Username { get; set; }
    }
}
