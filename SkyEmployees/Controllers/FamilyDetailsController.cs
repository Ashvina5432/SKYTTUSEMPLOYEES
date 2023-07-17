using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkyEmployees.BL;
using SkyEmployees.Core;

namespace SkyEmployees.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FamilyDetailsController : ControllerBase
    {
        FamilyDetailsBL _bl;
        public FamilyDetailsController(FamilyDetailsBL bl)
        {
            _bl = bl;
        }

        [HttpGet]
        public List<FamilyDetails> GetFamilyDetails()
        {
            return _bl.GetAllDetails();
        }
        [HttpGet]
        public FamilyDetails? Search(Guid id)
        {
            return _bl.Search(new FamilyDetails { Id=id});
        }
        [HttpPost]
        public FamilyDetails? AddFmilyDetails(FamilyDetails familyDetails)
        {
            return _bl.AddFamilyDetails(familyDetails);

        }
        [HttpPut]
        public FamilyDetails? UpdateFmilyDetail(Guid id, FamilyDetails familyDetails)
        {
            return _bl.UpdateFamilyDetail(id, familyDetails);
        }
        [HttpDelete]
        public bool Delete(Guid id)
        {
            return _bl.Delete(id);
        }
    }
}
