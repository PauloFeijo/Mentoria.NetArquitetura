using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICustomerService
    {
        Response<IEnumerable<CustomerResponseDto>> FindAll();
        Task<Response<CustomerResponseDto>> FindById(Guid id);
        Task<Response<CustomerResponseDto>> Create(CustomerRequestCreateDto customerDto);
        Task<Response<CustomerResponseDto>> Update(CustomerRequestUpdateDto customerDto);
        Task<Response<bool>> Delete(Guid id);
    }
}
