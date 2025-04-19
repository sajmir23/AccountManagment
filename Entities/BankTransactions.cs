using Shared.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BankTransactions
    {
        [Key]
        public int Id { get; set; }
        public ActionEnum Action { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public decimal Amount { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        [ForeignKey(nameof(BankAccounts))]
        public int? BankAccountId { get; set; }
        public BankAccounts? BankAccount { get; set; }

    }
}


