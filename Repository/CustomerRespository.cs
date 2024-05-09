using book_appointment.Interface;
using book_appointment.Models;
using book_appointment.Services;

namespace book_appointment.Repository
{
    public class CustomerRepository : ICustomer
    {
        readonly MyDbContext _myDbContext = new();

        public CustomerRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public UserData AddNewCustomer(UserData userData)
        {
            try
            {
                _myDbContext.UserData.Add(userData);
                _myDbContext.SaveChanges();
                return userData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}