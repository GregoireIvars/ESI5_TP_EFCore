namespace WebAPI.Models
{
    public class Session
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EventId { get; set; }
        public int RoomId { get; set; }
        public  Event Event { get; set; }
        public  Room Room { get; set; }
        public  ICollection<SessionSpeaker> SessionSpeakers { get; set; }
        public  ICollection<Rating> Ratings { get; set; }
    }
}

