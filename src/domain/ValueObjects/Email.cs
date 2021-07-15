using Flunt.Validations;

namespace Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
            AddNotifications(new Contract<ValueObject>()
                .Requires()
                .IsEmail(Address, "Email", "Invalid E-mail"));
        }

        public string Address { get; private set; }
    }
}
