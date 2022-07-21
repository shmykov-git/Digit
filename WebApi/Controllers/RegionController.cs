using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Api;
using WebApi.Data;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RegionController : ControllerBase
{
    private readonly DataContext context;

    public RegionController(DataContext context)
    {
        this.context = context;
    }

    [HttpGet("{countryId}")]
    public async Task<ActionResult<List<RegionRsp>>> Get(int countryId)
    {
        var regions = await context.Regions
            .Where(r => r.CountryId == countryId)
            .Select(r => r.Adapt<RegionRsp>())
            .ToListAsync();

        return Ok(regions);
    }
}