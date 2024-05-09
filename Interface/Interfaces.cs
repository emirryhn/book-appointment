using book_appointment.Models;

namespace book_appointment.Interface
{
    public interface IBookingAppointment
    {
        public void AddNewAppointment(BookAppointment bookAppointment);
        public List<BookAppointment> GetAppointmentByDate(DateTime date);

    }
    public interface ICustomer
    {
        public void AddNewCustomer(UserData userData);
    }

}