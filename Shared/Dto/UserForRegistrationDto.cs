using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public record UserForRegistrationDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email-i duhet te jete i disponueshem.")]
        [StringLength(25)]
        public string? Email { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        
        [StringLength(15)]
        public string Phone { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        [Required]
       
        [StringLength(50)]
        public string? UserName { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage =
            "Password duhet të përmbajë të paktën një shkronjë të vogël " +
            " një të madhe " +
            " një numër " +
            " një karakter special " +
            " të ketë të paktën 8 karaktere.")]
        public string? Password { get; set; }

        public ICollection<string>? Roles { get; set; }
    }
}
