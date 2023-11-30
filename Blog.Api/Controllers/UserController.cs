using Blog.Application.Services;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id) =>
        Ok(await userService.GetByIdAsync(id,true, HttpContext.RequestAborted));

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] User user) =>
        Ok(await userService.CreateAsync(user, true, HttpContext.RequestAborted));

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] User user) =>
        Ok(await userService.UpdateAsync(user, true, HttpContext.RequestAborted));

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id) =>
        Ok(await userService.DeleteByIdAsync(id, true, HttpContext.RequestAborted));
}