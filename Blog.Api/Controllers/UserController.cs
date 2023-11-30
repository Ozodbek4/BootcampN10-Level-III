using AutoMapper;
using Blog.Api.Dtos;
using Blog.Application.Services;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> GetAll() =>
        Ok(await userService.GetAllAsync(true));

    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id) =>
        Ok(await userService.GetByIdAsync(id, true, HttpContext.RequestAborted));

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] UserDto user) =>
        Ok(await userService.CreateAsync(mapper.Map<User>(user), true, HttpContext.RequestAborted));

    [HttpPut("{id:guid}")]
    public async ValueTask<IActionResult> Update([FromRoute] Guid id, [FromBody] UserDto user)
    {
        var found = await userService.GetByIdAsync(id, true, HttpContext.RequestAborted);

        return Ok(await userService.UpdateAsync(mapper.Map(user, found)!, true, HttpContext.RequestAborted));
    }

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id) =>
        Ok(await userService.DeleteByIdAsync(id, true, HttpContext.RequestAborted));
}