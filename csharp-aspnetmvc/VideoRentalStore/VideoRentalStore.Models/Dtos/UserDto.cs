using VideoRentalStore.Domain.Enums;

namespace VideoRentalStore.Models.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public string CardNumber { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? SubscriptionExpiresAt { get; set; }
    public int RemainingFreeRentals { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
    public bool IsSubscriptionExpired { get; set; }
}
