using System.ComponentModel.DataAnnotations;

namespace HikingAPI.Models
{
    public class Location
    {
        public int Id { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
    }
}