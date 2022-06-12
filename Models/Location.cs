using System.ComponentModel.DataAnnotations;

namespace HikingAPI.Models
{
    public class Location
    {
        public float latitude { get; set; }
        [Required]
        public float longitude { get; set; }
        [Required]
    }
}