namespace WebAPI.Models
{
    public class Event
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public EventStatus Status { get; set; }

        public int LocationId { get; set; }
        public required Location Location { get; set; }

        public int? CategoryId { get; set; }
        public required Category Category { get; set; }

        public required ICollection<Session> Sessions { get; set; }
        public required ICollection<EventParticipant> EventParticipants { get; set; }
    }
}