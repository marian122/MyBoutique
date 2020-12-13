using Microsoft.AspNetCore.Identity;
using MyBoutique.Common.BaseModels;
using System;

namespace MyBoutique.Models
{
    public class ApplicationUser : IdentityUser, IDeletableEntity
    {
        public string PasswordSalt { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}