using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Api;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserProfileController : ControllerBase
{
    private readonly DataContext context;

    public UserProfileController(DataContext context)
    {
        this.context = context;
    }

    //[Authorize]
    [HttpPut]
    public async Task<ActionResult<ProfileRsp>> Put([FromBody] ProfileRec profile)
    {
        if (!profile.RegionId.HasValue)
            return BadRequest(new ProfileRsp()
            {
                ErrorCode = ErrorCode.RegionIsNotEntered,
                Error = "Region is not entered"
            });

        //var user = User.Claims.First(c=>c.Type == "userId");
        //var userId = int.Parse(user.Value);
        var userId = 1;

        var location = context.Locations.FirstOrDefault(l => l.UserId == userId);

        if (location == null)
        {
            location = new Location() { RegionId = profile.RegionId.Value, UserId = userId };
            await context.Locations.AddAsync(location);
        }
        else
        {
            location.RegionId = profile.RegionId.Value;
        }

        await context.SaveChangesAsync();

        return Ok();
    }
}