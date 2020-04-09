using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace project1.ViewModels
{
    public class LocationViewModel
    {
        [Display(Name = "Name")]
        [Required]
        public string cityState { get; set; }
        [Required]
        public int locNum { get; set; }
    }
}
