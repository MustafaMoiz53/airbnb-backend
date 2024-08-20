using Microsoft.AspNetCore.Mvc;
using Practice.Data;
using Practice.Models;

namespace Practice.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RemarksController : Controller
    {
        private DataInterface _dataInterface;
        public RemarksController(DataInterface dataInterface)
        {
            _dataInterface = dataInterface;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Remarks>> GetRemarks()
        {
            return Ok(_dataInterface.GetAllRemarks());
        }

        [HttpPost]
        public ActionResult PostRemark([FromBody] Remarks remark)
        {
            _dataInterface.AddRemark(remark);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetRemarkBYID(int id)
        {
            Remarks remark = _dataInterface.GetRemarkBYID(id);
            if (remark != null)
            {
                return Ok(remark);
            }
            return NotFound("User not found!");
        }
        
        [HttpGet("Remarks/CampID")]
        public ActionResult<IEnumerable<Remarks>> GetRemarkBYCampID(int campid)
        {
            return Ok(_dataInterface.GetRemarkBYCampID(campid));
        }
        [HttpGet("Remarks/UserID")]
        public ActionResult<IEnumerable<Booking>> GetRemarkByUserId(int userID)
        {
            return Ok(_dataInterface.GetRemarkByUserId(userID));
        }
    }
}
