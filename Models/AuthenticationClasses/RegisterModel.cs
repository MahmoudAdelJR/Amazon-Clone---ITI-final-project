using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AuthenticationClasses
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name Is Requierd")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Is Requierd")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Is Requierd")]
        public string Password { get; set; }

        [Required(ErrorMessage = "FisrtName Is Requierd")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName Is Requierd")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address Is Requierd")]
        public string Address { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        [MaxLength(50)]
        public string Street { get; set; }
        [MaxLength(10)]
        public string PostalCode { get; set; }
    }
}
