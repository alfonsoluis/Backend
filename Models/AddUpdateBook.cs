namespace Backend.Models
{
    public class AddUpdateBook
    {
        public required string Title { get; set; }
        public required string Author { get; set; }

        public required string Genre { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
    }
}
