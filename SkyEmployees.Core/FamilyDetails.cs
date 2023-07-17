using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEmployees.Core
{
    public class FamilyDetails
    {
        public Guid? Id { get; set; }

        public Guid EmployeeId { get; set; }
        public string FName { get; set; } = string.Empty;
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public Guid RelationId { get; set; }
       public string Relation { get; set; } = string.Empty;

    }
}
