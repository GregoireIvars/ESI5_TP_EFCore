namespace WebAPI.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public  string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Company { get; set; }
        public required string JobTitle { get; set; }
        public  ICollection<EventParticipant> EventParticipants { get; set; }
        public  ICollection<Rating> Ratings { get; set; }
    }
}