using VideoRentalStore.Domain.Base;
using VideoRentalStore.Domain.Enums;

namespace VideoRentalStore.Domain.Entities;

public class Cast : BaseEntity
{
    public string MovieId { get; set; }
    public string Name { get; set; }
    public Part Part { get; set; }
}
