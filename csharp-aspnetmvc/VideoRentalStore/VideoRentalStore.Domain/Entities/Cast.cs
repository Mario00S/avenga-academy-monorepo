using VideoRentalStore.Domain.Base;
using VideoRentalStore.Domain.Enums;

namespace VideoRentalStore.Domain.Entities;

public class Cast : BaseEntity
{
    public int MovieId { get; set; }
    public Movie Movie { get; set; } //used for navigation
    public string Name { get; set; }
    public CastRole Role { get; set; }
}
