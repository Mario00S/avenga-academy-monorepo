using VideoRentalStore.Domain.Entities;

namespace VideoRentalStore.Models.ViewModels
{
    public class MovieDetailsViewModel
    {
        public Movie Movie { get; set; }
        public List<Cast> CastMembers { get; set; } = new List<Cast>();
    }
}
