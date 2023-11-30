using Blog.Application.Services;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BlogsController(IBlogService blogsService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id) =>
        Ok(await blogsService.GetByIdAsync(id, true, HttpContext.RequestAborted));

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] Blogs blog) =>
        Ok(await blogsService.CreateAsync(blog, true, HttpContext.RequestAborted));

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] Blogs blog) =>
        Ok(await blogsService.UpdateAsync(blog, true, HttpContext.RequestAborted));

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id) =>
        Ok(await blogsService.DeleteByIdAsync(id, true, HttpContext.RequestAborted));
}