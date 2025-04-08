namespace WebAPI.Models
{
    public class SessionSpeaker
    {
        public int SessionId { get; set; }
        public int SpeakerId { get; set; }
        public required string Role { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? AttendanceDate { get; set; }

        public  Session Session { get; set; }
        public  Speaker Speaker { get; set; }
    }
}

