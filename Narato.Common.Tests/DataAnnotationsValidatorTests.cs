using FluentAssertions;
using Narato.Common.Exceptions;
using Narato.Common.Tests.Stubs;
using Narato.Common.Validation;
using System;
using Xunit;

namespace Narato.Common.Tests
{
    public class DataAnnotationsValidatorTests
    {
        [Fact]
        public void InvalidAnnotatedModel_GetValidationErrors_ShouldReturnErrors()
        {
            var model = new Contact { EmailAddress = "bla" };
            var validator = new DataAnnotationsValidator();

            var errors = validator.GetValidationErrors(model);

            errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void ValidAnnotatedModel_GetValidationErrors_ShouldReturnNoErrors()
        {
            var model = new Contact { FirstName = "John", LastName = "Doe", EmailAddress = "test@test.be" };
            var validator = new DataAnnotationsValidator();

            var errors = validator.GetValidationErrors(model);

            errors.Count.Should().Be(0);
        }

        [Fact]
        public void InvalidAnnotatedModel_Validate_ShouldThrowValidationException()
        {
            var model = new Contact { EmailAddress = "bla" };
            var validator = new DataAnnotationsValidator();

            Action action = () =>
            {
                validator.Validate(model);
            };

            action.ShouldThrow<ModelValidationException>();
        }
    }
}
