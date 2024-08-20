using Microsoft.AspNetCore.Mvc;
using Practice.Data;
using Practice.Models;

namespace Practice.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AdminController : Controller
    {
        private DataInterface _dataInterface;
        public AdminController(DataInterface dataInterface)
        {
            _dataInterface = dataInterface;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Admin>> GetAdmins()
        {
            return Ok(_dataInterface.GetAllAdmins());
        }

        [HttpPost]
        public ActionResult PostAdmin([FromBody] Admin admin)
        {
            _dataInterface.AddAdmin(admin);
            return Ok();
        }

        [HttpPost("Campsite")]
        public ActionResult PostCamp([FromBody] Camp camp)
        {
            _dataInterface.AddCamp(camp);
            return Ok();
        }

        [HttpGet("Authentication")]
        public int GetAdminAuthentication(string email, string password)
        {
            return _dataInterface.GetAdminAuthentication(email, password);
        }
    }
}
