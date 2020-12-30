using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OracleCOEWorkTracking.ViewModels
{
    public class ServiceCallResult<T>
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Result { get; set; }
        public int ResultCount { get; set; }

        public ServiceCallResult() { }
        public ServiceCallResult(string message, bool success, T result)
        {
            Title = success ? "Success" : "Error";
            Message = message;
            Success = success;
            Result = result;
        }

        public static ServiceCallResult<T> CreateSuccessResult(string message, T result)
        {
            return new ServiceCallResult<T>(message, true, result);
        }

        public static ServiceCallResult<T> CreateErrorResult(string message, T result)
        {
            return new ServiceCallResult<T>(message, false, result);
        }
    }
}
