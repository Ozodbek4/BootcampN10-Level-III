using AutoMapper;
using Blog.Api.Dtos;
using Blog.Application.Services;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CommentController(ICommentService commentService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> GetAll() =>
        Ok(await commentService.GetAllAsync(true));

    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id) =>
        Ok(await commentService.GetByIdAsync(id, true, HttpContext.RequestAborted));

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] CommentDto comment) =>
        Ok(await commentService.CreateAsync(mapper.Map<Comment>(comment), true, HttpContext.RequestAborted));

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] CommentDto comment) =>
        Ok(await commentService.UpdateAsync(mapper.Map<Comment>(comment), true, HttpContext.RequestAborted));

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id) =>
        Ok(await commentService.DeleteByIdAsync(id, true, HttpContext.RequestAborted));
}