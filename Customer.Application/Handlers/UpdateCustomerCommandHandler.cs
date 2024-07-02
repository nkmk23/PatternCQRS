using Customer.Application.Commands;
using Customer.Domain.Entities.Customer;
using Customer.Domain.Interfaces.Infrastructure;

namespace Customer.Application.Handlers
{
    public class UpdateCustomerCommandHandler
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> Handle(UpdateCustomerCommand command)
        {
            CustomerDTO customer = new CustomerDTO
            {
                CustomerId = command.CustomerId,
                CompanyId = command.CompanyId,
                Email = command.Email,
                Fax = command.Fax,
                Name = command.Name,
                LastLogin = command.LastLogin,
                Password = command.Password,
                PortalId = command.PortalId,
                RoleId = command.RoleId,
                StatusId = command.StatusId,
                Telephone = command.Telephone,
                Username = command.Username
            };
            return await _customerRepository.UpdateCustomerAsync(customer);
        }
    }
}
