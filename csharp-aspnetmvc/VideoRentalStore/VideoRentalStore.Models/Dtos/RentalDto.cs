namespace VideoRentalStore.Models.Dtos;

public class RentalDto
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int UserId { get; set; }
    public DateTime RentedOn { get; set; }
    public DateTime? ReturnedOn { get; set; }
    public string MovieTitle { get; set; }
}
