using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequstParameters
{
    public class BaseResponse<TData,TError>
    {
        public TData? Data { get; set; }
        public TError? Error;
        public bool Result { get; set; }
        public int StatusCode {  get; set; }
    }
}
