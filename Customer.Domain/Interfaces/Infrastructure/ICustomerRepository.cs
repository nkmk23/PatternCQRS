using Customer.Domain.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Interfaces.Infrastructure
{
    public interface ICustomerRepository
    {
        Task<int> AddCustomerAsync(CustomerDTO customer);
        Task<int> UpdateCustomerAsync(CustomerDTO customer);
        Task<int> DeleteCustomerAsync(int customerId);
        Task<CustomerDTO> GetCustomerByIdAsync(int customerId);
    }
}
