using SkyEmployees.Core;
using SkyEmployees.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEmployees.BL
{
    public class EmployeeRelationBL
    {
        EmployeeRelationRepository _repository;

        public EmployeeRelationBL(EmployeeRelationRepository repository)

        {
            _repository=repository;
        }
        public EmployeeRelation? AddRelation(EmployeeRelation employeeRelation)
        {

            var id = _repository.AddRelation(employeeRelation);
            if (id != null)
            {
                employeeRelation.Id = (Guid)id;
            }

            return employeeRelation;

        }
        public List<EmployeeRelation> GetAllRelation()
        {
            return _repository.GetAllRelation();
        }
        public EmployeeRelation?  Search(EmployeeRelation employeeRelation)
        {
            return _repository.Search(employeeRelation);
        }
        public EmployeeRelation? UpdateRelation( Guid id, EmployeeRelation employeeRelation)
        {
            return _repository.UpdateRelation(id, employeeRelation);

        }
        public bool DeleteRelation(Guid id)
        {
            return _repository.DeleteRelation(id);

        }
    }
}
