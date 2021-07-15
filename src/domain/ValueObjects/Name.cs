using Flunt.Validations;

namespace Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<ValueObject>()
                .Requires()
                .IsNotEmpty(FirstName, "FirstName", "FirstName shouldn't be empty")
                .IsNotEmpty(LastName, "LastName", "LastName shouldn't be empty"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
