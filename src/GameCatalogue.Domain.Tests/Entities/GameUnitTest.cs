using FluentAssertions;
using GameCatalogue.Domain.Entities;
using GameCatalogue.Domain.Validation;
using System;
using Xunit;

namespace GameCatalogue.Domain.Tests.Entities
{
    public class GameUnitTest
    {
        [Fact(DisplayName = "Create Game With Valid State")]
        public void CreateGame_WithValidParameters_ResultObjectValidState() 
        {
            Action action = () => new Game(1, "Game Name", "Game Producer", "Game Action", 1, "Game image");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Game With Negative id Value")]
        public void CreateGame_NegativeIdValue_DomainExceptionInvalidId() 
        {
            Action action = () => new Game(-1, "Game Name", "Game Producer", "Game Action", 1, "Game image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Game With Short Name Value")]
        public void CreateGame_ShortNameValue_DomainExceptionShortName() 
        {
            Action action = () => new Game(1, "Ga", "Game Producer", "Game Action", 1, "Game image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Game With Missing Name Value")]
        public void CreateGame_MissingNameValue_DomainExceptionRequiredName() 
        {
            Action action = () => new Game(1, "", "Game Producer", "Game Action", 1, "Game image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Game With Null Name Value")]
        public void CreateGame_WithNullNameValue_DomainExceptionInvalidName() 
        {
            Action action = () => new Game(1, null, "Game Producer", "Game Action", 1, "Game image");
            action.Should().Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Game Invalid Quantity Value")]
        public void CreateGame_InvalidQuantityValue_DomainException() 
        {
            Action action = () => new Game(1, "Game Name", "Game Producer", "Game Action", -1, "Game image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid quantity value");
        }

        [Fact(DisplayName = "Create Game With Zero Quantity Value")]
        public void CreateGame_ZeroQuantityValue_DomainException() 
        {
            Action action = () => new Game(1, "Game Name", "Game Producer", "Game Action", 0, "Game image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid quantity value");
        }

        [Fact(DisplayName = "Create Game With Long Image Name")]
        public void CreateGame_LongImageName_DomainExceptionLongImageName() 
        {
            Action action = () => new Game(1, "Game Name", "Game Producer", "Game Action", 1,
            "Game image toooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooogggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact(DisplayName = "Create Game With Null Image Name")]
        public void CreateGame_WithNullImageName_NoDomainException() 
        {
            Action action = () => new Game(1, "Game Name", "Game Producer", "Game Action", 1, null);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Game With Image Null Reference Exception")]
        public void CreateGame_WithNullImageName_NoNullReferenceException() 
        {
            Action action = () => new Game(1, "Game Name", "Game Producer", "Game Action", 1, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Create Game With Empty Image Name")]
        public void CreateGame_WithEmptyImageName_NoDomainException() 
        {
            Action action = () => new Game(1, "Game Name", "Game Producer", "Game Action", 1, "");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
    }
}
