using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public class BankTransactionForCreationDto
    {
        public ActionEnum Action { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public decimal Amount { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? BankAccountId { get; set; }
    }
}
