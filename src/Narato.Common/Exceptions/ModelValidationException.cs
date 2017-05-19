using Narato.Common.Models;
using System;

namespace Narato.Common.Exceptions
{
    [Serializable]
    public class ModelValidationException : Exception
    {
        protected ModelValidationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public ModelValidationException(IModelValidationDictionary<string> validationMessages) : base()
        {
            ValidationMessages = validationMessages;
        }

        public ModelValidationException(IModelValidationDictionary<string> validationMessages, string message) : base(message)
        {
            ValidationMessages = validationMessages;
        }

        public ModelValidationException(IModelValidationDictionary<string> validationMessages, string message, Exception inner) : base(message, inner)
        {
            ValidationMessages = validationMessages;
        }

        public IModelValidationDictionary<string> ValidationMessages { get; }
    }
}
