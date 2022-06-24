using System.ComponentModel.DataAnnotations;

namespace HikingAPI.Models
{
    /// <summary>
    /// Represents one specific hike 
    /// </summary>
    public class Hiking
    {
        /// <summary>
        /// Unique ID for the hike
        /// </summary>
        public int ID { get; set; }
        [Required]
        /// <summary>
        /// Duration of the hike in hours
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// Drop of the hike in meters
        /// </summary>
        public int Drop { get; set; }
        /// <summary>
        /// Total distance of the hike in kilometers
        /// </summary>
        public int Distance { get; set; }
        /// <summary>
        /// Difficulty of the hike from 0 to 5; 5 beign the most difficult level
        /// </summary>
        public int Difficulty { get; set; }
        /// <summary>
        /// Name of the hike
        /// </summary>
        public string Title { get; set; }
        [Required]
        /// <summary>
        /// Description of the hike
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// City near the hike 
        /// </summary>
        public string City { get; set; }
        
    }   
}
