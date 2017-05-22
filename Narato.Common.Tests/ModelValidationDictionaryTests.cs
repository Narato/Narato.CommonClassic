using Narato.Common.Models;
using Newtonsoft.Json;
using Xunit;

namespace Narato.Common.Tests
{
    public class ModelValidationDictionaryTests
    {
        [Fact]
        public void SerializeJson_ReturnCorrectJson()
        {
            var dictionary = new ModelValidationDictionary<string>();
            dictionary.Add("FirstName", "John");
            dictionary.Add("LastName", "Doe");

            var json = JsonConvert.SerializeObject(dictionary);

            Assert.Equal(json, "{\"FirstName\":[\"John\"],\"LastName\":[\"Doe\"]}");
        }
    }
}
