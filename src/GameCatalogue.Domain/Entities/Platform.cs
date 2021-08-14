using GameCatalogue.Domain.Validation;
using System.Collections.Generic;

namespace GameCatalogue.Domain.Entities
{
    public sealed class Platform : Entity
    {
        public string Name { get; private set; }

        public ICollection<Game> Games { get; set; }

        public Platform(string name)
        {
            ValidateDomain(name);
        }

        public Platform(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name) 
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name) 
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");

            Name = name;
        }
    }
}
