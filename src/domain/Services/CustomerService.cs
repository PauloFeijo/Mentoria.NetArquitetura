using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Domain.ValueObjects;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Response<IEnumerable<CustomerResponseDto>> FindAll() 
            => new(_repository.FindAll().Select(c => CustomerResponseDto.From(c)));

        public async Task<Response<CustomerResponseDto>> FindById(Guid id) 
            => new(CustomerResponseDto.From(await _repository.FindById(id)));

        public async Task<Response<CustomerResponseDto>> Create(CustomerRequestCreateDto customerDto)
        {
            var customer = new Customer
            (
                name: new Name(customerDto.FirstName, customerDto.LastName),
                document: new IdentificationDocument(customerDto.Document),
                email: new Email(customerDto.Email),
                address: new Address(customerDto.Address),
                createdBy: customerDto.CreatedBy
            );

            if (customer.IsValid)
            {
                await _repository.Create(customer);
            }

            return new(CustomerResponseDto.From(customer), customer.Notifications);
        }

        public async Task<Response<CustomerResponseDto>> Update(CustomerRequestUpdateDto customerDto)
        {
            var customer = await _repository.FindById(customerDto.Id);

            if (customer is null)
            {
                return new(null, CreateNotification("Customer not found!", $"Customer with id [{customerDto.Id}] not found"));
            }

            customer.Update(customerDto);

            if (customer.IsValid)
            {
                await _repository.Update(customer);
            }

            return new(CustomerResponseDto.From(customer), customer.Notifications);
        }

        public async Task<Response<bool>> Delete(Guid id)
        {
            var customer = await _repository.FindById(id);

            if (customer is null)
            {
                return new(false, CreateNotification("Customer not found!", $"Customer with id [{id}] not found"));
            }

            await _repository.Delete(customer);

            return new (true);
        }

        private IEnumerable<Notification> CreateNotification(string key, string notification) 
            => new List<Notification>() { new (key, notification) };
    }
}
