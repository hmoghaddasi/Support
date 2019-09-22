using System;
using Support.Application.Contract.Constant;
using Support.Application.Contract.DTO;

namespace Support.Application.Service
{
    public static class BaseResponseHelper
    {
        public static BaseResponseDTO Success(string message = BaseResponse.SuccessMessage)
        {
            return new BaseResponseDTO
            {
                Message = message,
                ResultCode = BaseResponse.SuccessCode
            };
        }

        public static BaseResponseDTO Failure(string exception)
        {
            return new BaseResponseDTO
            {
                Message = $"{BaseResponse.FailureMessage}{Environment.NewLine}{exception}",
                ResultCode = BaseResponse.FailureCode
            };
        }
    }
}
