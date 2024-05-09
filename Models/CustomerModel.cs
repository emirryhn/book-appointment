using System.Text.Json.Serialization;

namespace book_appointment.Models
{
    public class UserData
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}