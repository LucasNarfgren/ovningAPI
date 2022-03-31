using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ÖvningAPI.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        [StringLength(25,MinimumLength = 2, ErrorMessage = "First Should be more than 2 and less than 25.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "It is required to confirm your password.")]
        [Compare("Password", ErrorMessage = "Confirm password and password does not match.")]
        public string ConfirmPassword { get; set; }

        public int AdressId { get; set; }
        public Adress Adress { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
