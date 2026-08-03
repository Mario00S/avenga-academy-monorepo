using VideoRentalStore.Domain.Base;
using VideoRentalStore.Domain.Enums;

namespace VideoRentalStore.Domain.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; }
    public int Age { get; set; }
    public string CardNumber { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? SubscriptionExpiresAt { get; set; }
    //refactoring - making changes to IsSubscriptionExpired due to it's references it's easier to keep this property instead of removing it
    public bool IsSubscriptionExpired =>
        SubscriptionExpiresAt.HasValue && DateTime.UtcNow >= SubscriptionExpiresAt.Value;

    //public bool IsSubscriptionExpired
    //{
    //    get
    //    {
    //        // First check: does the user even have an expiry date?
    //        if (!SubscriptionExpiresAt.HasValue)
    //        {
    //            // Free tier users have no expiry → not expired
    //            return false;
    //        }

    //        // Second check: compare current time with expiry date
    //        if (DateTime.UtcNow >= SubscriptionExpiresAt.Value)
    //        {
    //            return true; // expired
    //        }

    //        return false; // still active
    //    }
    //}
    //each user account starts with 3 free rentals
    public int RemainingFreeRentals { get; set; } = 3;
    public SubscriptionType SubscriptionType { get; set; }
}
