using MyEWalletApp.Models.ReturnDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEWalletApp.Commons
{
    public static class ResponseHelper
    {
        public static Response<T> CreateResponse<T>(string message, T data, bool status, Exception error = null)
        {
            var result = new Response<T>();
            result.Message = message;
            result.Data = data;
            result.IsSuccessful = status;

            if(error != null)
            {
                result.Errors.Add("error", new List<string>() {error.Message, error.StackTrace, error.Source, error.HelpLink});
            }

            return result;
        }
    }
}
