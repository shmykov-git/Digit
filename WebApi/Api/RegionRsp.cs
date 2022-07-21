namespace WebApi.Api;

public class RegionRsp
{
    public int RegionId { get; set; }
    public int CountryId { get; set; }
    public string Name { get; set; } = default!;
}