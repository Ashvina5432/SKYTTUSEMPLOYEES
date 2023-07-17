using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkyEmployees.BL;
using SkyEmployees.Core;

namespace SkyEmployees.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeAddressController : ControllerBase
    {
        EmployeeAddressBL _bl;

        public EmployeeAddressController(EmployeeAddressBL bL)
        {
            _bl = bL;
        }

        [HttpGet]
        public List<EmployeeAddress> GetAllAddress()

        {
             return _bl.GetAllAddress();

        }
        [HttpGet]
        public EmployeeAddress GetAddress(Guid? id)
        {
            return _bl.Search(new EmployeeAddress() { Id = id});

        }
        [HttpPost]
       public EmployeeAddress? AddAddress(EmployeeAddress empaddress)
        {
           
            return _bl.AddAddress(empaddress);
           
        }

        [HttpPut]
        public EmployeeAddress UpdateAddress(Guid id, EmployeeAddress empaddress)
        {
            return _bl.UpdateAddress(id, empaddress);
        }
        [HttpDelete]
         
        public bool DeleteAddress(Guid id)
        {
            return _bl.DeleteAddress(id);
        }
    }
}
