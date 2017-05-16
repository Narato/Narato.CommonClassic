using Narato.Common.Models;
using System;

namespace Narato.Common.Exceptions
{
    [Serializable]
    public class ModelValidationException : Exception
    {
        public ModelValidationException() { }
        public ModelValidationException(string message) : base(message) { }
        public ModelValidationException(string message, Exception inner) : base(message, inner) { }
        protected ModelValidationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public ModelValidationException(IModelValidationDictionary<string> validationMessages)
        {
            ValidationMessages = validationMessages;
        }

        public IModelValidationDictionary<string> ValidationMessages { get; }
    }
}
