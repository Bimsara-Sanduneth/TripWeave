using System.ComponentModel.DataAnnotations;

namespace TripWeave.Api.DTOs;

public class PatchTripDto
{
    [MinLength(2)]
    public string? Destination { get; set; }

    [Range(1, 365)]
    public int? Days { get; set; }

    [Range(0, 100000000)]
    public decimal? Budget { get; set; }
}
