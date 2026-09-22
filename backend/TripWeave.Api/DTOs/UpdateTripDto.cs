using System.ComponentModel.DataAnnotations;

namespace TripWeave.Api.DTOs;

public class UpdateTripDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Destination { get; set; } = string.Empty;

    [Range(1, 365)]
    public int Days { get; set; }

    [Range(typeof(decimal), "0.01", "1000000000")]
    public decimal Budget { get; set; }
}
