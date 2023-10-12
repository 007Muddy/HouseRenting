using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseRenting.Models
{
    [Table("House")]
    public class House
    {
        
        public int ID { get; set; }
      
        public string Type { get; set; }
       
        public string Color { get; set; }
       
       
        public decimal Area { get; set; }
        
        public decimal  Price { get; set; }
        
        public string Rooms { get; set; }
      
        public string Location { get; set; }
        
        public DateTime ConstructionDate { get; set; }
     
        public string Description { get; set; }

        public IFormFile? Image { get; set; }
        


    }
}
