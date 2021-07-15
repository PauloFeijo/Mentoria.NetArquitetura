using Domain.Dtos;
using Domain.ValueObjects;
using System;

namespace Domain.Entities
{
    public class Customer : Entity
    {
        public Customer() { }

        public Customer(Name name, IdentificationDocument document, Email email, Address address, string createdBy)
        {
            Id = Guid.NewGuid();
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            CreatedAt = DateTime.Now;
            CreatedBy = createdBy;
            UpdatedAt = CreatedAt;
            UpdatedBy = CreatedBy;

            AddNotifications(Name, Document, Email, Address);
        }

        public Name Name { get; private set; }
        public IdentificationDocument Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        public void Update(CustomerRequestUpdateDto customerDto)
        {
            Name = new(customerDto.FirstName, customerDto.LastName);
            Document = new(customerDto.Document);
            Email = new(customerDto.Email);
            Address = new(customerDto.Address);
            UpdatedBy = customerDto.UpdatedBy;
            UpdatedAt = DateTime.Now;

            AddNotifications(Name, Document, Email, Address);
        }
    }
}
