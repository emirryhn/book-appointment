using System.Text.Json.Serialization;

namespace book_appointment.Models
{
    public class BookAppointment
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int WaitingNumber { get; set; }
        public DateTime DateTimeAppointment { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}