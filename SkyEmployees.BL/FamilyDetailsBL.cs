using SkyEmployees.Core;
using SkyEmployees.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyEmployees.BL
{
    public class FamilyDetailsBL
    {
        FamilyDetailsRepository _repository;

        public FamilyDetailsBL(FamilyDetailsRepository repository)
        {
            _repository=repository;

        }
        public  List<FamilyDetails> GetAllDetails()
        {
            return _repository.GetAllDetails();
        }
        public FamilyDetails Search(FamilyDetails familyDetails)  
        {
            return _repository.Search(familyDetails);

        }
        public FamilyDetails? AddFamilyDetails(FamilyDetails familyDetails)
        {

            var id = _repository.AddFamilyDetails(familyDetails);
            if (id != null)
            {
                familyDetails.Id = (Guid)id;
            }

            return familyDetails;

        }
        
        public FamilyDetails UpdateFamilyDetail(Guid id, FamilyDetails familyDetails)
        {
            return _repository.UpdateFamilyDetail(id, familyDetails);

        }
        public bool Delete(Guid id)
        {
            return _repository.Delete(id);

        }

    }
}
