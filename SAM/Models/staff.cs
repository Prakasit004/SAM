using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SAM.Models
{
    public class Staff
    {
        [Key]
        public string PSUPassport { get; set; }

        public string StaffTitleName { get; set; }
        public string StaffName { get; set; }
        public string StaffLastName { get; set; }
        
        [Required(ErrorMessage = "Please type your Organization.")]
        public string OrganName { get; set; }
        

        [Required(ErrorMessage = "Please type your Position.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Please type your E-mail.")]
        public string StaffEmail { get; set; }

        [Required(ErrorMessage = "Please type your Tel.")]
        public string StaffTel { get; set; }
    }
}