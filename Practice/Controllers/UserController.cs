using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Practice.Data;
using Practice.Models;

namespace Practice.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : Controller
    {
        private DataInterface _dataInterface;
        public UserController(DataInterface dataInterface)
        {
            _dataInterface = dataInterface;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetUsers()
        {
            return Ok(_dataInterface.GetAllUsers());
        }

        [HttpPost]
        public ActionResult PostUser([FromBody] User user)
        {
            _dataInterface.AddUser(user);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetUserBYID(int id)
        {
            User user = _dataInterface.GetUserBYID(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("User not found!");
        }

        [HttpGet("Authentication")]
        public int GetAuthentication( string email, string password)
        {
            return _dataInterface.GetAuthentication(email, password);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            // Get the existing user by ID
            User existingUser = _dataInterface.GetUserBYID(id);
            if (existingUser == null)
            {
                return NotFound("User not found!");
            }

            // Update the existing user's properties with the new data
            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = updatedUser.Password;
            existingUser.Age = updatedUser.Age;

            // Save the updated user back to the data store
            _dataInterface.UpdateUser(existingUser);

            return Ok("User updated successfully!");
        }

    }

}
