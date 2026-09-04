using VideoRentalStore.Domain.Enums;

namespace VideoRentalStore.Models.Dtos;

public class CastDto
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public string Name { get; set; }
    public CastRole Role { get; set; }
}
