using book_appointment.Models;
using Microsoft.EntityFrameworkCore;

namespace book_appointment.Services
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }
        public MyDbContext(DbContextOptions<MyDbContext> context) : base(context)
        {

        }
        public DbSet<BookAppointment> BookAppointment { get; set; }
        public DbSet<UserData> UserData { get; set; }

    }
}