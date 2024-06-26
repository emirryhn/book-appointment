using book_appointment.Interface;
using book_appointment.Models;
using book_appointment.Services;
using Microsoft.IdentityModel.Tokens;
using Nager.Date;

namespace book_appointment.Repository
{
    public class AppointmentRepository : IBookingAppointment
    {
        readonly MyDbContext _myDbContext = new();
        public AppointmentRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public BookAppointment AddNewAppointment(BookAppointment bookAppointment)
        {
            try
            {
                //SEARCH USER NAME
                var customerName = (from db in _myDbContext.UserData
                                    where db.Name.Equals(bookAppointment.UserName)
                                    select db.Name);
                if (customerName.IsNullOrEmpty())
                {
                    throw new("Customer not found, please add or use another user!");
                }
                else
                {
                    //GET LAST WAITING NUMBER
                    if (WeekendSystem.IsWeekend(bookAppointment.DateTimeAppointment, CountryCode.ID))
                    {
                        throw new("Is weekend, select another date");
                    }
                    var lastValue = _myDbContext.BookAppointment.OrderByDescending(a => a.WaitingNumber).Select(e => e.WaitingNumber).FirstOrDefault();
                    int nextValue = lastValue + 1;
                    bookAppointment.WaitingNumber = nextValue;
                    _myDbContext.BookAppointment.Add(bookAppointment);
                    _myDbContext.SaveChanges();
                    return bookAppointment;
                }
            }
            catch
            {
                throw;
            }
        }

        public List<BookAppointment> GetAppointmentByDate(DateTime date)
        {
            try
            {
                var result = _myDbContext.BookAppointment.Where(a => a.DateTimeAppointment.Date == date.Date).ToList();
                if (result.Count == 0)
                {
                    throw new("No Appointment on " + date + " !");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
