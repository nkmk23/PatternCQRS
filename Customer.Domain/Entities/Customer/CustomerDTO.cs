﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Entities.Customer
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Name { get; set; }
        public DateTime? LastLogin { get; set; }
        public string Password { get; set; }
        public int PortalId { get; set; }
        public int RoleId { get; set; }
        public int StatusId { get; set; }
        public string Telephone { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string Username { get; set; }
    }
}