using VideoRentalStore.Domain.Base;

namespace VideoRentalStore.Domain.Entities;

public class Rental : BaseEntity
{
    public int MovieId { get; set; }
    public int UserId { get; set; }
    public DateTime RentedOn { get; set; }
    public DateTime? ReturnedOn { get; set; }
}
