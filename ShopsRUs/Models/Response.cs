using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Models
{
    public class Response<T>
    {
        public Response(string success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        public string Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
