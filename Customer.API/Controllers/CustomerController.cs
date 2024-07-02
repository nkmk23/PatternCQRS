using Customer.Application.Commands;
using Customer.Application.Handlers;
using Customer.Application.Queries;
using Customer.Domain.Entities.Customer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using Customer.Domain.Entities.Customer.OUTPUT;

namespace Customer.API.Controllers
{
    [Route("api/Redarbor")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CreateCustomerCommandHandler _createHandler;
        private readonly DeleteCustomerCommandHandler _deleteHandler;
        private readonly UpdateCustomerCommandHandler _updateHandler;
        private readonly GetCustomerByIdQueryHandler _getHandler;
        private readonly GetAllCustomersQueryHandler _getAllHandler;

        public CustomerController(
            CreateCustomerCommandHandler createHandler,
            DeleteCustomerCommandHandler deleteHandler,
            UpdateCustomerCommandHandler updateHandler,
            GetCustomerByIdQueryHandler getHandler,
            GetAllCustomersQueryHandler getAllHandler)
        {
            _createHandler = createHandler;
            _deleteHandler = deleteHandler;
            _updateHandler = updateHandler;
            _getHandler = getHandler;
            _getAllHandler = getAllHandler;
        }

        [HttpPost]
        [SwaggerResponse(statusCode: 200, type: typeof(BodyResponse<int>), description: "Customer created successfully")]
        [SwaggerResponse(statusCode: 400, type: typeof(BodyResponse<string>), description: "Bad input parameter")]
        [SwaggerResponse(statusCode: 500, type: typeof(BodyResponse<string>), description: "Internal Error")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)
        {
            var response = new BodyResponse<int>();
            try
            {
                var customerId = await _createHandler.Handle(command);
                response.StatusCode = "200";
                response.StatusDesc = "Customer created successfully";
                response.Data = customerId;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = "500";
                response.StatusDesc = "Internal Error";
                return StatusCode(500, response);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(statusCode: 200, type: typeof(BodyResponse<int>), description: "Customer deleted successfully")]
        [SwaggerResponse(statusCode: 400, type: typeof(BodyResponse<string>), description: "Bad input parameter")]
        [SwaggerResponse(statusCode: 500, type: typeof(BodyResponse<string>), description: "Internal Error")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var response = new BodyResponse<int>();
            try
            {
                var result = await _deleteHandler.Handle(new DeleteCustomerCommand { CustomerId = id });
                response.StatusCode = "200";
                response.StatusDesc = "Customer deleted successfully";
                response.Data = result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = "500";
                response.StatusDesc = "Internal Error";
                return StatusCode(500, response);
            }
        }

        [HttpPut("{id}")]
        [SwaggerResponse(statusCode: 200, type: typeof(BodyResponse<int>), description: "Customer updated successfully")]
        [SwaggerResponse(statusCode: 400, type: typeof(BodyResponse<string>), description: "Bad input parameter")]
        [SwaggerResponse(statusCode: 500, type: typeof(BodyResponse<string>), description: "Internal Error")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerCommand command)
        {
            var response = new BodyResponse<int>();
            try
            {
                if (id != command.CustomerId)
                {
                    response.StatusCode = "400";
                    response.StatusDesc = "Bad input parameter";
                    return BadRequest(response);
                }

                var result = await _updateHandler.Handle(command);
                response.StatusCode = "200";
                response.StatusDesc = "Customer updated successfully";
                response.Data = result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = "500";
                response.StatusDesc = "Internal Error";
                return StatusCode(500, response);
            }
        }

        [HttpGet("{id}")]
        [SwaggerResponse(statusCode: 200, type: typeof(BodyResponse<CustomerDTO>), description: "Customer found")]
        [SwaggerResponse(statusCode: 400, type: typeof(BodyResponse<string>), description: "Bad input parameter")]
        [SwaggerResponse(statusCode: 404, type: typeof(BodyResponse<string>), description: "Customer not found")]
        [SwaggerResponse(statusCode: 500, type: typeof(BodyResponse<string>), description: "Internal Error")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var response = new BodyResponse<CustomerDTO>();
            try
            {
                var customer = await _getHandler.Handle(new GetCustomerByIdQuery { CustomerId = id });
                if (customer == null)
                {
                    response.StatusCode = "404";
                    response.StatusDesc = "Customer not found";
                    return NotFound(response);
                }

                response.StatusCode = "200";
                response.StatusDesc = "Customer found";
                response.Data = customer;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = "500";
                response.StatusDesc = "Internal Error";
                return StatusCode(500, response);
            }
        }

        [HttpGet]
        [SwaggerResponse(statusCode: 200, type: typeof(BodyResponse<List<CustomerDTO>>), description: "Customers found")]
        [SwaggerResponse(statusCode: 400, type: typeof(BodyResponse<string>), description: "Bad input parameter")]
        [SwaggerResponse(statusCode: 500, type: typeof(BodyResponse<string>), description: "Internal Error")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var response = new BodyResponse<List<CustomerDTO>>();
            try
            {
                var customers = await _getAllHandler.Handle();
                response.StatusCode = "200";
                response.StatusDesc = "Customers found";
                response.Data = customers;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = "500";
                response.StatusDesc = "Internal Error";
                return StatusCode(500, response);
            }
        }
    }
}
