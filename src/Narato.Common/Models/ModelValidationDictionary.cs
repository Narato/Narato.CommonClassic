using System;
using System.Collections.Generic;

namespace Narato.Common.Models
{
    public class ModelValidationDictionary<T> : Dictionary<string, ICollection<T>>, IModelValidationDictionary<T>
    {
        public void Add(string field, T item)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (!ContainsKey(field))
            {
                Add(field, new List<T>() { item });
                return;
            }
            if (this[field].Contains(item))
            {
                throw new InvalidOperationException($"item for field {field} was already added to validationDictionary: {item.ToString()}");
            }
            this[field].Add(item);
        }
    }
}
