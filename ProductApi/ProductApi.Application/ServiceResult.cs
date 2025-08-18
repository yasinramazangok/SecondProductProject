using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application
{
    public class ServiceResult<T>
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; } = string.Empty;
        public T? Data { get; private set; }

        private ServiceResult(bool isSuccess, string message, T? data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        public static ServiceResult<T> Success(T data, string message = "")
            => new ServiceResult<T>(true, message, data);

        public static ServiceResult<T> Fail(string message)
            => new ServiceResult<T>(false, message, default);
    }
}
