using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkyEmployees.BL;
using SkyEmployees.Core;

namespace SkyEmployees.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeRelationController : ControllerBase
    {
        EmployeeRelationBL _bl;
        public EmployeeRelationController(EmployeeRelationBL bl)
        {
            _bl = bl;
            
        }

        [HttpGet]
        public List<EmployeeRelation> GetAllRelation()
        {
            return _bl.GetAllRelation();
        }
        [HttpGet]
        public EmployeeRelation GetRelation(Guid? id, string relation)
        {
            return _bl.Search(new EmployeeRelation() { Id = id, Relation = relation });

        }
        [HttpPost]
        public EmployeeRelation? AddRelation(EmployeeRelation employeeRelation)
        {

            return _bl.AddRelation(employeeRelation);

        }
        [HttpPut]
        public EmployeeRelation UpdateRelation(Guid id, EmployeeRelation emprelation)
        {
            return _bl.UpdateRelation(id, emprelation);
        }
        [HttpDelete]

        public bool DeleteRelation(Guid id)
        {
            return _bl.DeleteRelation(id);
        }
    }
}
