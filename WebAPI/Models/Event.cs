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
        public Location Location { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Session> Sessions { get; set; }
        public ICollection<EventParticipant> EventParticipants { get; set; }
    }
}