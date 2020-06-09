using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FromScratch.ViewModels
{
    public class SignUpVM
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "This Email isn't valid!")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Password must be more than {2} and at last {1} symbol.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords didn't match!")]
        public string ConfirmPassword { get; set; }
    }
}
