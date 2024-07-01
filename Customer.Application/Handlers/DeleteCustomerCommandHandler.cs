using Customer.Application.Commands;
using Customer.Domain.Interfaces.Infrastructure;

namespace Customer.Application.Handlers
{
    public class DeleteCustomerCommandHandler
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> Handle(DeleteCustomerCommand command)
        {
            return await _customerRepository.DeleteCustomerAsync(command.CustomerId);
        }
    }
}
