using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public class CurrenciesForUpdateDto
    {
        private string? _code;
        public string? Code
        {
            get => _code;
            set => _code = value?.ToUpper();
        }

        public string? Description { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
