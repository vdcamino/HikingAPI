using System.ComponentModel.DataAnnotations;

namespace HikingAPI.Models
{
    public class Issue
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Location starting_point { get; set; }
        public Location end_point { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Completed { get; set; }
    }
        
    public enum Priority
    {
        Low, Medium, High
    }

   
}
