namespace WebAPI.Models
{
    

    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public  ICollection<Event> Events { get; set; }
    }
}