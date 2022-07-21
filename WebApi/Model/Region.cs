using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Model;

public class Region
{
    public int RegionId { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; } = default!;
    public string Name { get; set; } = default!;
}