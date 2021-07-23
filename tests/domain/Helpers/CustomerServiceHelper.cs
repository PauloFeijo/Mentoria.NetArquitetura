using AutoFixture;
using Domain.Entities;
using Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Tests.Helpers
{
    public static class CustomerServiceHelper
    {
        private const string ValidIdentificationDocument = "01234567890";
        private const string ValidEmail = "test@test.com";
        private static Fixture fixture = new Fixture();

        public static IEnumerable<Customer> CreateMany(int qtd = 10) 
            => new List<Customer>(qtd)
            .Select(c => CreateOne());
                /*new Customer
                (
                    fixture.Create<Name>(),
                    new IdentificationDocument(ValidIdentificationDocument),
                    new Email(ValidEmail),
                    fixture.Create<Address>(),
                    fixture.Create<string>()
                )
            );*/

        public static Customer CreateOne() => new Customer
        (
            fixture.Create<Name>(),
            new IdentificationDocument(ValidIdentificationDocument),
            new Email(ValidEmail),
            fixture.Create<Address>(),
            fixture.Create<string>()
        );

        public static IEnumerable<Customer> CreateEmptyList() => Enumerable.Empty<Customer>();
    }
}
