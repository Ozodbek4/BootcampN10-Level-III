using AutoMapper;
using Blog.Api.Dtos;
using Blog.Application.Services;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BlogsController(IBlogService blogsService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> GetAll() =>
        Ok(await blogsService.GetAllAsync(true));

    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id) =>
        Ok(await blogsService.GetByIdAsync(id, true, HttpContext.RequestAborted));

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] BlogsDto blog) =>
        Ok(await blogsService.CreateAsync(mapper.Map<Blogs>(blog), true, HttpContext.RequestAborted));

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromRoute] Guid id, [FromBody] BlogsDto blog)
    {
        var found = await blogsService.GetByIdAsync(id, true, HttpContext.RequestAborted);

        return Ok(await blogsService.UpdateAsync(mapper.Map(blog, found)!, true, HttpContext.RequestAborted));
    }

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id) =>
        Ok(await blogsService.DeleteByIdAsync(id, true, HttpContext.RequestAborted));
}