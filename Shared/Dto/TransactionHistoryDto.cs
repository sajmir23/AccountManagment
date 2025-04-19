using Shared.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public class TransactionHistoryDto
    {
        public decimal Amount { get; set; }
        public ActionEnum Action { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }
        public decimal BalancaAferTransaction { get; set; }

    }
}
