using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Api;
using WebApi.Data;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CountryController : ControllerBase
{
    private readonly DataContext context;

    public CountryController(DataContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<CountryRsp>>> Get()
    {
        var countries = await context.Countries.Select(c => c.Adapt<CountryRsp>()).ToListAsync();

        return Ok(countries);
    }
}