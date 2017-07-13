using Narato.Common.Models;

namespace Narato.Common.Validation
{
    public interface IModelValidator
    {
        IModelValidationDictionary<string> GetValidationErrors(object instance);

        void Validate(object instance);
    }
}
