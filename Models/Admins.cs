using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Admin.Models
{
    public class Admins : BaseClass
    {


        public string Name { get; set; }
        public string Email { get; set; }
        [ForeignKey("adminProfile")]
        public string profileID { get; set; }

        //public virtual ICollection<Contact> Contacts { get; set; }
        public virtual IdentityUser adminProfile { get; set; }
    }
}
