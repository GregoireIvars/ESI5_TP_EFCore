namespace WebAPI.Models
{
    public class Room
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Capacity { get; set; }
        public int LocationId { get; set; }
        public  Location Location { get; set; }

        public  ICollection<Session> Sessions { get; set; }
    }
    

}