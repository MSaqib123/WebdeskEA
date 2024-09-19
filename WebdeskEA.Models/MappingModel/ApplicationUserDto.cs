using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Models.MappingModel
{
    public class ApplicationUserDto
    {
        public string Id { get; set; } // For update scenarios, especially if you need to know the user ID

        [Required]
        public string UserName { get; set; } // Equivalent to UserName in IdentityUser

        [Required]
        [EmailAddress]
        public string Email { get; set; } // Equivalent to Email in IdentityUser

        public string? Name { get; set; } // Custom property

        public string? StreetAddress { get; set; } // Custom property

        public string? City { get; set; } // Custom property

        public string? State { get; set; } // Custom property

        public string? PostalCode { get; set; } // Custom property
        public string? ProfileImage { get; set; } // Custom property

        public string? PhoneNumber { get; set; } // Equivalent to PhoneNumber in IdentityUser

        public string? Password { get; set; } // Password for creation

        public string? CurrentPassword { get; set; } // Current password for updates

        [NotMapped]
        public IFormFile? ProfileImageForSave { get; set; } // File upload for profile image

    }
}
