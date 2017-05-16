namespace Narato.Common.Models
{
    public class ValidationErrorContent<T>
    {
        public IModelValidationDictionary<T> ValidationMessages { get; set; }
    }
}
