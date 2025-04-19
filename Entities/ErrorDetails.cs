using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entities
{
   public class ErrorDetails
   {
            public bool Result { get; set; }
            public int StatusCode { get; set; }
            public string? Errors { get; set; }
            public override string ToString() => JsonSerializer.Serialize(this);
   }
}
