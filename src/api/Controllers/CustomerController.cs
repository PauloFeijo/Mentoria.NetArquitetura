using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerResponseDto>> Get()
        {
            return Ok(_service.FindAll().Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponseDto>> GetOne(Guid id)
        {
            var response = await _service.FindById(id);

            return response.Data is null
                ? NotFound()
                : Ok(response.Data);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerResponseDto>> Create([FromBody] CustomerRequestCreateDto request)
        {
            var response = await _service.Create(request);

            return response.IsValid
                ? Ok(response.Data)
                : BadRequest(response.Notifications);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerResponseDto>> Update(Guid id, [FromBody] CustomerRequestUpdateDto request)
        {
            if (id != request.Id)
                return BadRequest("Id is not equals to request Id");

            var response = await _service.Update(request);

            return response.IsValid
                ? Ok(response.Data)
                : BadRequest(response.Notifications);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await _service.Delete(id);

            return response.IsValid
                ? NoContent()
                : BadRequest(response.Notifications);
        }
    }
}
