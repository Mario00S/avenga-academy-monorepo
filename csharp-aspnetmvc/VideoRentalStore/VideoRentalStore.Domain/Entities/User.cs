using VideoRentalStore.Domain.Base;
using VideoRentalStore.Domain.Enums;

namespace VideoRentalStore.Domain.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; }
    public int Age { get; set; }
    public string CardNumber { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsSubscriptionExpired { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
}
