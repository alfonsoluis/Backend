namespace Backend.Models
{
    public class AddUpdateBook
    {
        public required string Title { get; set; }
        public required string Author { get; set; }

        public required string Genre { get; set; }
        public DateTime PublisDate { get; set; } = DateTime.Now;
    }
}
