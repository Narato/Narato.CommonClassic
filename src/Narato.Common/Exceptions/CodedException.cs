using System;

namespace Narato.Common.Exceptions
{
    [Serializable]
    public class CodedException : Exception
    {
        public string ErrorCode { get; }

        public CodedException() { }
        public CodedException(string errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
        public CodedException(string errorCode, string message, Exception inner) : base(message, inner)
        {
            ErrorCode = errorCode;
        }
        protected CodedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
