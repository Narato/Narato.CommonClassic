using FluentAssertions;
using Narato.Common.Models;
using Newtonsoft.Json;
using Xunit;

namespace Narato.Common.Tests
{
    public class ModelValidationDictionaryTests
    {
        [Fact]
        public void FilledDictionary_SerializedToJson_ShouldReturnCorrectJson()
        {
            var dictionary = new ModelValidationDictionary<string>();
            dictionary.Add("FirstName", "John");
            dictionary.Add("LastName", "Doe");

            var json = JsonConvert.SerializeObject(dictionary);

            json.Should().BeEquivalentTo("{\"FirstName\":[\"John\"],\"LastName\":[\"Doe\"]}");
        }
    }
}
