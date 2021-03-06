﻿using System.ComponentModel.DataAnnotations;

namespace MyBoutique.Infrastructure.ViewModels
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
