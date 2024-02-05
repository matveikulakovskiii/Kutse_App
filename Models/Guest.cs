using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kutse_App.Models
{
    public class Guest
    {
        [Required(ErrorMessage ="Sisesta nimi siia")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Sisesta poosti adress siia")]
        [RegularExpression(@".+\@.+\..+",ErrorMessage="Vale postkats")]
        public string Email { get; set; }

        [RegularExpression(@"\+372.+", ErrorMessage = "Vale number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Tee oma valik")]
        public bool? WillAttend { get; set; }

        public string Notes { get; set; }

    }
}