using book_appointment.Models;

namespace book_appointment.Interface
{
    public interface IBookingAppointment
    {
        public BookAppointment AddNewAppointment(BookAppointment bookAppointment);
        public List<BookAppointment> GetAppointmentByDate(DateTime date);

    }
    public interface ICustomer
    {
        public UserData AddNewCustomer(UserData userData);
    }

}