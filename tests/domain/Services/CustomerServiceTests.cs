using AutoFixture;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Domain.Services;
using Domain.Tests.Helpers;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Tests.Services
{
    public class CustomerServiceTests
    {
        private const string ExceptionMessage = "Exception message";
        private readonly Fixture _fixture;
        private readonly CustomerService _service;
        private readonly Mock<ICustomerRepository> _repository;

        public CustomerServiceTests()
        {
            _fixture = new Fixture();
            _repository = new Mock<ICustomerRepository>(MockBehavior.Strict);
            _service = new CustomerService(_repository.Object);
        }

        [Fact]
        public void FindAll_WhenFound_ShouldExecuteCorrectly()
        {
            var expectedCustomers = CustomerServiceHelper.CreateMany();
            _repository.Setup(r => r.FindAll())
                .Returns(expectedCustomers);

            var result = _service.FindAll();

            result.Data
                .Should().BeEquivalentTo(expectedCustomers
                    .Select(c => CustomerResponseDto.From(c)));
            _repository.VerifyAll();
        }

        [Fact]
        public void FindAll_WhenNotFound_ShouldReturnEmpty()
        {
            var expectedCustomers = CustomerServiceHelper.CreateEmptyList();
            _repository.Setup(r => r.FindAll())
                .Returns(expectedCustomers);

            var result = _service.FindAll();

            result.Data.Should().BeEmpty();
            _repository.VerifyAll();
        }

        [Fact]
        public void FindAll_WhenRepositoryFail_ShouldThrowException()
        {
            var exception = new Exception(ExceptionMessage);
            _repository.Setup(r => r.FindAll())
                .Throws(exception);

            Func<Response<IEnumerable<CustomerResponseDto>>> func = _service.FindAll;

            func.Should().Throw<Exception>().WithMessage(ExceptionMessage);
            _repository.VerifyAll();
        }

        //-----------------------------------------------------------------------

        [Fact]
        public async Task FindById_WhenFound_ShouldExecuteCorrectly()
        {
            var id = new Guid();
            var expectedCustomer = CustomerServiceHelper.CreateOne();
            _repository.Setup(r => r.FindById(id))
                .ReturnsAsync(expectedCustomer);

            var result = await _service.FindById(id);

            result.Data
                .Should().BeEquivalentTo(CustomerResponseDto.From(expectedCustomer));
            _repository.VerifyAll();
        }

        [Fact]
        public async Task FindById_WhenNotFound_ShouldReturnNull()
        {
            var id = new Guid();
            var expectedCustomer = (Customer)null;
            _repository.Setup(r => r.FindById(id))
                .ReturnsAsync(expectedCustomer);

            var result = await _service.FindById(id);

            result.Data.Should().BeNull();
            _repository.VerifyAll();
        }

        [Fact]
        public void FindById_WhenRepositoryFail_ShouldThrowException()
        {
            var id = new Guid();
            var exception = new Exception(ExceptionMessage);
            _repository.Setup(r => r.FindById(id))
                .Throws(exception);

            Func<Guid, Task<Response<CustomerResponseDto>>> func = _service.FindById;

            func(id).Should().Throw<Exception>().WithMessage(ExceptionMessage);
            _repository.VerifyAll();
        }
    }
}
