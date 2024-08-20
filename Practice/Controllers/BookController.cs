using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Practice.Data;
using Practice.Models;

namespace Practice.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BookController : Controller
    {
        private DataInterface _dataInterface;

        public BookController(DataInterface dataInterface) 
        {
            _dataInterface = dataInterface;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Booking>>GetBooking()
        {
            return Ok(_dataInterface.GetAllBooking());
        }

        [HttpPost]
        public ActionResult PostBooking([FromBody] Booking booking) 
        {
            _dataInterface.AddBooking(booking);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetBookingBYID(int id) 
        {
            Booking booking = _dataInterface.GetBookingBYID(id);
            if (booking != null) 
            {
                return Ok(booking);
            }
            return NotFound("Booking not found!");
        }

        [HttpGet("CheckAvailability")]
        public ActionResult<bool> CheckAvailability(int campID, string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);

            bool isAvailable = _dataInterface.IsSpotAvailable(campID, start, end);

            return Ok(isAvailable);
        }
        [HttpGet("Bookings/CampID")]
        public ActionResult<IEnumerable<Booking>> GetBookingByCampId(int campID)
        {
            return Ok(_dataInterface.GetBookingByCampId(campID));
        }
        [HttpGet("Bookings/UserID")]
        public ActionResult<IEnumerable<Booking>> GetBookingByUserId(int userID)
        {
            return Ok(_dataInterface.GetBookingByUserId(userID));
        }
    }
}
