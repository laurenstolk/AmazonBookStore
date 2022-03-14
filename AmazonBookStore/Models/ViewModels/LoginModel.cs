using System;
using System.ComponentModel.DataAnnotations;

namespace AmazonBookStore.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public string ReturnUrl;

    }
}
