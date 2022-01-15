using System;
using System.Collections.Generic;
using System.Text;

namespace MyEWalletApp.Models.ReturnDTOs
{
    public class Response<T>
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
        public T Data { get; set; }
        public Response()
        {
            Errors = new Dictionary<string, List<string>>();
        }
    }
}
