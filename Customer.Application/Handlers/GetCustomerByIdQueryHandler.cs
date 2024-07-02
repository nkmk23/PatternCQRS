using Customer.Application.Queries;
using Customer.Domain.Entities.Customer;
using Customer.Domain.Interfaces.Infrastructure;

namespace Customer.Application.Handlers
{
    public class GetCustomerByIdQueryHandler
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDTO> Handle(GetCustomerByIdQuery query)
        {
            return await _customerRepository.GetCustomerByIdAsync(query.CustomerId);
        }
    }
}
