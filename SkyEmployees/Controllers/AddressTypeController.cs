using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkyEmployees.BL;
using SkyEmployees.Core;

namespace SkyEmployees.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AddressTypeController : ControllerBase
    {
        AddressTypeBL _bl;
        public AddressTypeController(AddressTypeBL bl)
        {
            _bl = bl;

        }

        [HttpGet]
        public List<AddressTypes> GetAllAddressType()
        {
            return _bl.GetAllAddressType();
        }
        [HttpGet]
        public AddressTypes GetAddressType(Guid? id, string? addressType)
        {
            return _bl.Search(new AddressTypes() { Id = id, AddressType = addressType });

        }
        [HttpPost]
        public AddressTypes? AddAddressType(AddressTypes addressTypes)
        {

            return _bl.AddAddressType(addressTypes);

        }
        [HttpPut]
        public AddressTypes UpdateAddressType(Guid id, AddressTypes addressTypes)
        {
            return _bl.UpdateAddressType(id,addressTypes);
        }
        [HttpDelete]

        public bool DeleteAddressType(Guid id)
        {
            return _bl.DeleteAddressType(id);
        }
    }
}
