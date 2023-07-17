using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEmployees.Core
{
    public class EmployeeAddress
    {
        public Guid? Id { get; set; }
        public string Address { get; set; }

        public Guid? AddressTypeId { get; set; }
        public Guid? EmployeeId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string AddressType { get; set; } = string.Empty;


    }
}
