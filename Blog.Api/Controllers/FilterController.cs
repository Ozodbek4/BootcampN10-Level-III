using Blog.Application.Common.Models;
using Blog.Application.Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilterController(IFilterService filterService) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] FilterPagination pagination) =>
        Ok(await filterService.GetFilter(pagination));
}