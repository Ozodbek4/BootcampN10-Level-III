using AutoMapper;
using Interceptor.Api.Models;
using Interceptor.Application.Common.Services;
using Interceptor.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Interceptor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService, IMapper mapper) : ControllerBase
{
    [HttpGet("{id:Guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id) =>
        Ok(await userService.GetByIdAsync(id, true, HttpContext.RequestAborted));

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] UserDto user) =>
        Ok(await userService.CreateAsync(mapper.Map<User>(user), true, HttpContext.RequestAborted));

    [HttpPut("{id:guid}")]
    public async ValueTask<IActionResult> Update([FromRoute] Guid id, [FromBody] UserDto user)
    {
        var found = await userService.GetByIdAsync(id);
        var mappedUser = mapper.Map(user,found);

        return Ok(await userService.UpdateAsync(mappedUser!, true, HttpContext.RequestAborted));
    }

    [HttpDelete]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid id) =>
        Ok(await userService.DeleteByIdAsync(id, true, HttpContext.RequestAborted));
}