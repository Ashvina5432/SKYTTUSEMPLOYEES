using SkyEmployees.Core;
using SkyEmployees.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEmployees.BL
{
    public class AddressTypeBL
    {
        AddressTypeRepository _repository;

        public AddressTypeBL(AddressTypeRepository repository)

        {
            _repository = repository;
        }
        public AddressTypes? AddAddressType(AddressTypes addressTypes)
        {

            var id = _repository.AddAddressType(addressTypes);
            if (id != null)
            {
                addressTypes.Id = (Guid)id;
            }

            return addressTypes;

        }
        public List<AddressTypes> GetAllAddressType()
        {
            return _repository.GetAllAddressType();
        }
        public AddressTypes? Search(AddressTypes addressTypes)
        {
            return _repository.Search(addressTypes);
        }
        public AddressTypes? UpdateAddressType(Guid id,AddressTypes addressTypes)
        {
            return _repository.UpdateAddressType(id, addressTypes);

        }
        public bool DeleteAddressType(Guid id)
        {
            return _repository.DeleteAddressType(id);

        }
    }
}
