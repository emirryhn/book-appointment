using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using book_appointment.Interface;
using book_appointment.Models;
using book_appointment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace book_appointment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingAppointment _iBookAppointment;
        private readonly ICustomer _iCustomer;

        public BookingController(IBookingAppointment iBookingAppointment, ICustomer iCustomer)
        {
            _iBookAppointment = iBookingAppointment;
            _iCustomer = iCustomer;
        }

        //AGENCY ADD NEW APPOINTMENT
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<BookAppointment>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookAppointment>> AddNewAppointment(BookAppointment bookAppointment)
        {
            var result = _iBookAppointment.AddNewAppointment(bookAppointment);
            return Ok(result);
        }

        // //AGENCY ADD NEW USER
        [HttpPost]
        [Route("new-user")]
        [ProducesResponseType(typeof(IEnumerable<UserData>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddNewUser(UserData userData)
        {
            var result = _iCustomer.AddNewCustomer(userData);
            return Ok("User " + result.Name + " Added");
        }


        // //AGENCY LIST APPOINTMENTS BY DATE
        [HttpGet]
        [Route("date")]
        [ProducesResponseType(typeof(IEnumerable<BookAppointment>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetApointmentsByDate(DateTime date)
        {
            var getAppointment = await Task.FromResult(_iBookAppointment.GetAppointmentByDate(date));
            return Ok(getAppointment);
        }

    }
}