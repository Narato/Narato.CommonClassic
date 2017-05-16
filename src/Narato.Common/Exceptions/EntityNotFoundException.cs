using System;

namespace Narato.Common.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : CodedException
    {
        public EntityNotFoundException() { }
        public EntityNotFoundException(string errorCode, string message) : base(errorCode, message) { }
        public EntityNotFoundException(string errorCode, string message, Exception inner) : base(errorCode, message, inner) { }
        protected EntityNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
