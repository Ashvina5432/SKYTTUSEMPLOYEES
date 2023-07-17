using SkyEmployees.Core;
using SkyEmployees.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEmployees.BL
{
    public class EmployeeAddressBL
    {
        EmployeeAddressRepository _repository;

        public EmployeeAddressBL(EmployeeAddressRepository repository)
        {
            _repository = repository;
        }

      
        public EmployeeAddress? AddAddress(EmployeeAddress empaddress)
        {

            var id= _repository.AddAddress(empaddress);
             if (id != null)
            {
                empaddress.Id = (Guid)id;
            }

             return empaddress;
           

            

        }
         public List<EmployeeAddress> GetAllAddress()
        {
            return _repository.GetAllAddress();
        }
        public EmployeeAddress? Search(EmployeeAddress empaddress)
        {
            return _repository.Search(empaddress);
        }
        public EmployeeAddress UpdateAddress(Guid id, EmployeeAddress empaddress)
        {
            return _repository.UpdateAddress(id, empaddress);

        }
        public bool DeleteAddress(Guid id)
        {
            return _repository.DeleteAddress(id);

        }

    }
}
