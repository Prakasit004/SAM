using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAM.Models
{
    public class Staff
    {
        [Key]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please type your Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please type your Organization.")]
        public string Organization { get; set; }

        [Required(ErrorMessage = "Please type your E-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please type your Tel.")]
        public string Tel { get; set; }
    }
}