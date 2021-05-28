using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Models
{
    public class Image
    {
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        [Required]
        [Display(Name = "Date Modified")]
        public DateTime DateModified { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public bool IsPrivate { get; set; }
    }
}
