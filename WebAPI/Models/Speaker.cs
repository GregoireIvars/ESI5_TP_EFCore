namespace WebAPI.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Bio { get; set; }
        public required string Email { get; set; }
        public required string Company { get; set; }

        public  ICollection<SessionSpeaker> SessionSpeakers { get; set; }
    }
}

