using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public  class BankAccounts
    {
        [Key]
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }    
        public string? Description { get; set; }
        public decimal Balance { get; set; } = 0;
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        [ForeignKey(nameof(Clients))]
        public int? ClientId { get; set; }
        public Clients? Client { get; set; }

        [ForeignKey(nameof(Currencies))]
        public int? CurrenciestId { get; set; }    
        public Currencies? Currenciest { get; set; }
    }
    //get qe lejon qe te jete vetem e lexueshme property ndersa
    //set ben te mundur qe te modifikohet pra ti caktohet nje vlere
}
