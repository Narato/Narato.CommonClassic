using System.Collections.Generic;

namespace Narato.Common.Models
{
    public interface IModelValidationDictionary<T> : IDictionary<string, ICollection<T>>
    {
    }
}
