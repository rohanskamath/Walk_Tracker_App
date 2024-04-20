namespace Backend.Models.DTOs
{
    // This DTO is to Get all the properties
    public class RegionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? ImageURL { get; set; }
    }
}
