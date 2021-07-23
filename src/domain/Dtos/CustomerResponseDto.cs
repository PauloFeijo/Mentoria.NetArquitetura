using Domain.Entities;
using System;

namespace Domain.Dtos
{
    public class CustomerResponseDto
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public string UpdatedBy { get; private set; }

        public static CustomerResponseDto From(Customer customer)
            => customer is null ? null : new()
            {
                Id = customer.Id,
                FirstName = customer.Name.FirstName,
                LastName = customer.Name.LastName,
                Document = customer.Document.Document,
                Email = customer.Email.Address,
                Address = customer.Address.Description,
                CreatedAt = customer.CreatedAt,
                CreatedBy = customer.CreatedBy,
                UpdatedAt = customer.UpdatedAt,
                UpdatedBy = customer.UpdatedBy
            };
    }
}
