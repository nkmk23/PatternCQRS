using Customer.Domain.Entities.Customer;
using Customer.Domain.Interfaces.Infrastructure;
using Customer.Infrastructure.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using System.ComponentModel;

namespace Customer.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context, string connectionString)
        {
            _context = context;
            _connectionString = connectionString;
        }

        public async Task<int> AddCustomerAsync(CustomerDTO customer)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = @"INSERT INTO Customers (CompanyId, Email, Fax, Name, LastLogin, Password, PortalId, RoleId, StatusId, Telephone, Username) 
                          VALUES (@CompanyId, @Email, @Fax, @Name, @LastLogin, @Password, @PortalId, @RoleId, @StatusId, @Telephone, @Username);";

            return await connection.ExecuteScalarAsync<int>(query, new
            {
                @CompanyId = customer.CompanyId,
                @Email = customer.Email,
                @Fax = customer.Fax,
                @Name = customer.Name,
                @LastLogin = DateTime.Now,
                @Password = customer.Password,
                @PortalId = customer.PortalId,
                @RoleId = customer.RoleId,
                @StatusId = customer.StatusId,
                @Telephone = customer.Telephone,
                @Username = customer.Username,
            });
        }

        public async Task<int> UpdateCustomerAsync(CustomerDTO customer)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = @"UPDATE Customers SET CompanyId = @CompanyId, Email = @Email, Fax = @Fax, Name = @Name, LastLogin = @LastLogin, 
                          Password = @Password, PortalId = @PortalId, RoleId = @RoleId, StatusId = @StatusId, Telephone = @Telephone, 
                          Username = @Username, UpdatedOn = @UpdatedOn WHERE CustomerId = @CustomerId;";
            return await connection.ExecuteAsync(query, new
            {
                @CompanyId = customer.CompanyId,
                @Email = customer.Email,
                @Fax = customer.Fax,
                @Name = customer.Name,
                @LastLogin = DateTime.Now,
                @Password = customer.Password,
                @PortalId = customer.PortalId,
                @RoleId = customer.RoleId,
                @StatusId = customer.StatusId,
                @Telephone = customer.Telephone,
                @Username = customer.Username,
                @UpdatedOn = DateTime.Now,
            });
        }

        public async Task<int> DeleteCustomerAsync(int customerId)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = @"UPDATE FROM Customers SET StatusId = 2 WHERE CustomerId = @CustomerId;";
            return await connection.ExecuteAsync(query, new { CustomerId = customerId });
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int customerId)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = @"SELECT * FROM Customers WHERE CustomerId = @CustomerId;";
            return await connection.QueryFirstOrDefaultAsync<CustomerDTO>(query, new { CustomerId = customerId });
        }
    }
}