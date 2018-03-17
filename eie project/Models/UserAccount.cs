using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace eie_project.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage ="Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

         [Required(ErrorMessage = "Matric Number is required.")]
        public string MatricNumber { get; set; }

         [Required(ErrorMessage = "Select Level.")]
         public int Level { get; set; }
    }
}