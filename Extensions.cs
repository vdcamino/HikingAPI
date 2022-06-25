using HikingAPI.DTOs;
using HikingAPI.Models; 

namespace HikingAPI
{
    public static class Extensions
    {
        public static HikingDTO AsDto(this Hiking hiking)
        {
            return new HikingDTO(hiking.ID, hiking.Duration, hiking.Drop, hiking.Distance, hiking.Difficulty, hiking.Title, hiking.Description, hiking.City, hiking.CreatedDate);
        }
    }
}
