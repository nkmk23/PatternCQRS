using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Entities.Customer.OUTPUT
{
    public class BodyResponse<T>
    {
        public string StatusCode { get; set; }
        public string StatusDesc { get; set; }
        public T Data { get; set; }
    }
}
