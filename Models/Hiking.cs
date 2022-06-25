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
        [Required]
        public int ID { get; set; }
        /// <summary>
        /// Duration of the hike in hours
        /// </summary>
        [Required]
        public int Duration { get; set; }
        /// <summary>
        /// Drop of the hike in meters
        /// </summary>
        [Required]
        public int Drop { get; set; }
        /// <summary>
        /// Total distance of the hike in kilometers
        /// </summary>
        [Required]
        public int Distance { get; set; }
        /// <summary>
        /// Difficulty of the hike from 0 to 5; 5 beign the most difficult level
        /// </summary>
        [Required]
        public int Difficulty { get; set; }
        /// <summary>
        /// Name of the hike
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Description of the hike
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// City near the hike 
        /// </summary>
        [Required]
        public string City { get; set; }
        /// <summary>
        /// Date when the hike object was created
        /// </summary>
        public DateTimeOffset CreatedDate { get; set; }
    }
}
