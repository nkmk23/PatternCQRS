using Customer.Application.Commands;
using Customer.Application.Handlers;
using Customer.Application.Queries;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)
        {
            var customerId = await _createHandler.Handle(command);
            return Ok(customerId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _deleteHandler.Handle(new DeleteCustomerCommand { CustomerId = id });
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, UpdateCustomerCommand command)
        {
            if (id != command.CustomerId)
                return BadRequest();

            var result = await _updateHandler.Handle(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _getHandler.Handle(new GetCustomerByIdQuery { CustomerId = id });
            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _getAllHandler.Handle();
            return Ok(customers);
        }
    }
}
