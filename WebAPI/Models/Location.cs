namespace WebAPI.Models
{
    public class Location
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
        public required int Capacity { get; set; }

        public  ICollection<Event> Events { get; set; }
        public  ICollection<Room> Rooms { get; set; }
    }
}

