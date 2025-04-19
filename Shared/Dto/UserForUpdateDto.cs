using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public class UserForUpdateDto
    {
      
        
            [Required(ErrorMessage = "Name is a required field")]
            [StringLength(15, MinimumLength = 3, ErrorMessage = "Name should be between 3 and 15 characters")]
            public string? FirstName { get; set; }

            [Required(ErrorMessage = "LastName is a required field")]
            [StringLength(8, MinimumLength = 3, ErrorMessage = "LastName should be between 3 and 8 characters")]
            public string? LastName { get; set; }

            [Phone(ErrorMessage = "Invalid Phone Number format.")]
            public string? PhoneNumber { get; set; }

            [StringLength(50, ErrorMessage = "City name should not exceed 50 characters.")]
            public string? City { get; set; }

            [StringLength(50, ErrorMessage = "Country name should not exceed 50 characters.")]
            public string? Country { get; set; }

            public DateTime? DateUpdated { get; set; }
        
    }
}
