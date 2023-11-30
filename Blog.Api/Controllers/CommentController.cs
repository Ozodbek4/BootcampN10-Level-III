using Blog.Application.Services;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CommentController(ICommentService commentService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id) =>
        Ok(await commentService.GetByIdAsync(id, true, HttpContext.RequestAborted));

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] Comment comment) =>
        Ok(await commentService.CreateAsync(comment, true, HttpContext.RequestAborted));

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] Comment comment) =>
        Ok(await commentService.UpdateAsync(comment, true, HttpContext.RequestAborted));

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id) =>
        Ok(await commentService.DeleteByIdAsync(id, true, HttpContext.RequestAborted));
}