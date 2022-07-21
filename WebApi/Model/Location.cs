namespace WebApi.Model;

public class Location
{
    public int LocationId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int RegionId { get; set; }
    public Region Region { get; set; }
}