using System;
using System.Collections.Generic;
using System.Text;
using VideoRentalStore.Domain.Enums;

namespace VideoRentalStore.Models.ViewModels
{
    public class UserProfileViewModel
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string CardNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsSubscriptionExpired { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public IEnumerable<MovieViewModel> RentedMovies { get; set; }
    }
}
