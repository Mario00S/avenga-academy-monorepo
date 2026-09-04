using VideoRentalStore.Domain.Enums;

namespace VideoRentalStore.Models.Dtos;

public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Genre Genre { get; set; }
    public Language Language { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime ReleaseDate { get; set; }
    public TimeSpan Length { get; set; }
    public int AgeRestriction { get; set; }
    public int Quantity { get; set; }
    public List<CastDto> CastMembers { get; set; } = new List<CastDto>();
}
