using FluentAssertions;
using GameCatalogue.Domain.Entities;
using GameCatalogue.Domain.Validation;
using System;
using Xunit;

namespace GameCatalogue.Domain.Tests.Entities
{
    public class PlatformUnitTest
    {
        [Fact(DisplayName = "Create Platform With Valid State")]
        public void CreatePlatform_withValidParameters_ResultObjectValidState()
        {
            Action action = () => new Platform(1, "Platform Name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Platform With Negative id Value")]
        public void CreatePlatform_NegativeIdValue_DomainExceptionInvalidId() 
        {
            Action action = () => new Platform(-1, "Platform Name");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Platform With Short Name Value")]
        public void CreatePlatform_ShortNameValue_DomainExceptionShortName() 
        {
            Action action = () => new Platform(1, "Pl");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Platform With Missing Name Value")]
        public void CreatePlatform_MissingNameValue_DomainExceptionRequiredName() 
        {
            Action action = () => new Platform(1, "");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Platform With Null Name Value")]
        public void CreatePlatform_WithNullNameValue_DomainExceptionInvalidName() 
        {
            Action action = () => new Platform(1, null);
            action.Should().Throw<DomainExceptionValidation>();
        }
    }
}
