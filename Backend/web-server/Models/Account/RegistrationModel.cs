using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web_server.Models.Account
{
    public class RegistrationModel
    {
        [Required(ErrorMessage ="First Name is required")]
        [StringLength(20, ErrorMessage ="FirstName must be less than or equals 20 symbols")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Second Name is required")]
        [StringLength(20, ErrorMessage = "SecondName must be less than or equals 20 symbols")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(15, ErrorMessage = "Phone number must be less than or equals 20 symbols")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "Password must be no less than 6 symbols and no more than or equals 20 symbols", MinimumLength =6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage ="Passwords don't match")]
        public string ConfirmPassword { get; set; }

    }
}