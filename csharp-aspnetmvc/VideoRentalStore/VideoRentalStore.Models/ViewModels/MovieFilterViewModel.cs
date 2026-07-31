using System;
using System.Collections.Generic;
using System.Text;
using VideoRentalStore.Domain.Entities;
using VideoRentalStore.Domain.Enums;

namespace VideoRentalStore.Models.ViewModels
{
    public class MovieFilterViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? TitleFilter { get; set; }
        public Genre? GenreFilter { get; set; }
        public string? CastFilter { get; set; }
    }
}
