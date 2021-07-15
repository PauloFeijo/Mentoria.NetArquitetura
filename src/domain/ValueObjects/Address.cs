using Flunt.Validations;

namespace Domain.ValueObjects
{
    public class Address : ValueObject
    {
        private const int MinLength = 10;
        private const int MaxLength = 100;
        public Address(string description)
        {
            Description = description;

            if (Description.Length < MinLength)
                AddNotification("Address", $"Address should have minimum {MinLength} caracters.");

            if (Description.Length > MaxLength)
                AddNotification("Address", $"Address should have maximum {MaxLength} caracters.");
        }

        public string Description { get; private set; }
    }
}
