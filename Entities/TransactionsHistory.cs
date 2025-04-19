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
    public class TransactionsHistory
    {
        [Key]
        public int Id { get; set; }
        public decimal Amount {  get; set; }
        public ActionEnum Action { get; set; }
        public DateTime TransactionDate {  get; set; }
        public string? Description { get; set; }
        public decimal BalanceAferTransaction {  get; set; }
       

        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
        public Category? Categorys { get; set; }

        [ForeignKey(nameof(BankAccounts))]
        public int BankAccountId { get; set; }
        public BankAccounts? BankAccount { get; set; }
    }
}
