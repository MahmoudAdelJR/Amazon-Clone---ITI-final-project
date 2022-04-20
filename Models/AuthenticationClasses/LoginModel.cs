using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models.AuthenticationClasses
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name Is Requierd")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Is Requierd")]
        public string Password { get; set; }
    }
}