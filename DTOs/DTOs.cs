using System.ComponentModel.DataAnnotations;

namespace HikingAPI.DTOs
{
    public record HikingDTO([Required] int ID, int Duration, int Drop, int Distance, [Range(1, 5)] int Difficulty, [Required] string Title, string Description, string City, DateTimeOffset CreatedDate);
    public record CreateHikingDTO([Required] int Drop, [Required] int Distance, [Required] [Range(1, 5)] int Difficulty, [Required] string Title, string Description, [Required] string City);
    public record UpdateHikingDTO([Required] int Drop, [Required] int Distance, [Required] [Range(1, 5)] int Difficulty, [Required] string Title, string Description, [Required] string City);
}