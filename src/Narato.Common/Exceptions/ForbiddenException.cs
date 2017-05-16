using System;

namespace Narato.Common.Exceptions
{
    [Serializable]
    public class ForbiddenException : CodedException
    {
        public ForbiddenException() { }
        public ForbiddenException(string errorCode, string message) : base(errorCode, message) { }
        public ForbiddenException(string errorCode, string message, Exception inner) : base(errorCode, message, inner) { }
        protected ForbiddenException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
