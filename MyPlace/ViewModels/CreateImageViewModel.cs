using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.ViewModels
{
    public class CreateImageViewModel
    {
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public bool IsPrivate { get; set; }
    }
}
