using Customer.Domain.Entities.Customer;
using Customer.Domain.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Handlers
{
    public class GetAllCustomersQueryHandler
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerDTO>> Handle()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }
    }
}
