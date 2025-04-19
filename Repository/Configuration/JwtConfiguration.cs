using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class JwtConfiguration
    {
        public string? section { get; set; } = "JwtSettings";
        public string? validIssuer { get; set; }
        public string? validAudience { get; set; }
        public string? expires {  get; set; }
        public string? secretKey {  get; set; }
    }

}
