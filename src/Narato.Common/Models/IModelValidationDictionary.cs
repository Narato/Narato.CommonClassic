namespace Narato.Common.Models
{
    public interface IModelValidationDictionary<T>
    {
        void Add(string field, T item);

        bool ContainsKey(string field);

        int Count { get; }
    }
}
