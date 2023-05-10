using System;

namespace HttpsFrontWinForms.Model.AppService
{
    public class BusinessAppException : Exception
    {
        private string _code;

        public BusinessAppException(string message) : base(message)
        {

        }

        public BusinessAppException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public BusinessAppException(string errorCode, string message) : base(message)
        {
            _code = errorCode;
        }

        public string ErrorCode() => _code;
    }
}