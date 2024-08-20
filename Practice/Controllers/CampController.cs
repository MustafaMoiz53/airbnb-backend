using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Practice.Data;
using Practice.Models;

namespace Practice.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CampController : Controller
    {
        private DataInterface _dataInterface;
        public CampController(DataInterface dataInterface)
        {
            _dataInterface = dataInterface;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Camp>> GetCamps()
        {
            return Ok(_dataInterface.GetAllCamps());
        }


        [HttpGet("{id}")]
        public ActionResult GetCampBYID(int id)
        {
            Camp camp = _dataInterface.GetCampBYID(id);
            if (camp != null)
            {
                return Ok(camp);

            }
            return NotFound("Camp not found! Try another ID!");
        }

        [HttpGet("{name}/Camp")]
        public ActionResult GetCampBYNAME(string name)
        {
            Camp camp = _dataInterface.GetCampBYNAME(name);
            if (camp != null)
            {
                return Ok(camp);

            }
            return NotFound("Camp not found! Try another name!");
        }

        


        //[HttpGet("{id}/Reviews")]
        //public ActionResult G

    }
}


