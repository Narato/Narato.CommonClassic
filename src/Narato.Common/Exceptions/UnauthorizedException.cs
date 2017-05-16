using System;

namespace Narato.Common.Exceptions
{
    [Serializable]
    public class UnauthorizedException : CodedException
    {
        public UnauthorizedException() { }
        public UnauthorizedException(string errorCode, string message) : base(errorCode, message) { }
        public UnauthorizedException(string errorCode, string message, Exception inner) : base(errorCode, message, inner) { }
        protected UnauthorizedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { } 
    }
}
