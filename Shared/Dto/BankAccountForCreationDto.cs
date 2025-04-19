using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public class BankAccountForCreationDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public int? ClientId { get; set; }
        public int? CurrenciesId { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
