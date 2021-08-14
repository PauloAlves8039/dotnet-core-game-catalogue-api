using GameCatalogue.Domain.Validation;

namespace GameCatalogue.Domain.Entities
{
    public sealed class Game : Entity
    {
        public string Name { get; private set; }
        public string Producer { get; private set; }
        public string Gender { get; private set; }
        public int Quantity { get; private set; }
        public string Image { get; private set; }

        public int PlatformId { get; set; }
        public Platform Platform { get; set; }

        public Game(string name, string producer, string gender, int quantity, string image)
        {
            ValidateDomain(name, producer, gender, quantity, image);
        }

        public Game(int id, string name, string producer, string gender, int quantity, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name, producer, gender, quantity, image);
        }

        public void Update(string name, string producer, string gender, int quantity, string image, int platformId) 
        {
            ValidateDomain(name, producer, gender, quantity, image);
            PlatformId = platformId;
        }

        private void ValidateDomain(string name, string producer, string gender, int quantity, string image) 
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(producer), "Invalid producer. Producer is required");

            DomainExceptionValidation.When(producer.Length < 5, "Invalid producer, too short, minimum 5 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(gender), "Invalid gender. Gender is required");

            DomainExceptionValidation.When(gender.Length < 3, "Invalid gender, too short, minimum 3 characters");

            DomainExceptionValidation.When(quantity <= 0, "Invalid quantity value");

            DomainExceptionValidation.When(image?.Length > 250, "Invalid image name, too long, maximum 250 characters");

            Name = name;
            Producer = producer;
            Gender = gender;
            Quantity = quantity;
            Image = image;
        }
    }
}
