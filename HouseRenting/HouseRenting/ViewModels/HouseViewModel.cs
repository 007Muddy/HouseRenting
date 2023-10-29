
namespace HouseRenting.ViewModels
{
    public class HouseViewModel
    {
        public int ID { get; set; }
        public string? Type { get; set; }
        public string? Color { get; set; }
        public decimal Area { get; set; }
        public decimal Price { get; set; }
        public string? Rooms { get; set; }

        public string? Location { get; set; }
        public DateTime ConstructionDate { get; set; }
        public string? Description { get; set; }


        public IFormFile File { get; set; } = null; // Provide a default value

     
    }
}
