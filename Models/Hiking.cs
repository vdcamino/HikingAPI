using System.ComponentModel.DataAnnotations;

namespace HikingAPI.Models
{
    public class Hiking
    {
        public int ID { get; set; }
        [Required]
        public int Duration { get; set; }
        public int Drop { get; set; }
        public int Distance { get; set; }
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public Location starting_point { get; set; }
        public Location end_point { get; set; }
        
    }   
}
