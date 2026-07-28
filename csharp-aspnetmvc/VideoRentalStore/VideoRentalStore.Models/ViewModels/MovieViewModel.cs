namespace VideoRentalStore.Models.ViewModels;

public class MovieViewModel
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime RentedOn { get; set; }
    public DateTime? ReturnedOn { get; set; } // optional
    public int RentalId { get; set; }
}
