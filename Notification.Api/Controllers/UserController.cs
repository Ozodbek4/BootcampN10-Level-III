using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.Common.Identities.Services;
using Notification.Domain.Entities;

namespace Notification.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService service) =>
        _userService = service;

    [HttpGet]
    public async ValueTask<IActionResult> GetAll() =>
        Ok(await _userService.GetAllAsync(true));

    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id) =>
        Ok(await _userService.GetByIdAsync(id, true, HttpContext.RequestAborted));

    [HttpPut]
    public async ValueTask<IActionResult> Create([FromBody] User user) =>
        Ok(await _userService.CreateAsync(user, true, HttpContext.RequestAborted));

    [HttpPost]
    public async ValueTask<IActionResult> UpdateAsync([FromBody] User user)
    {
        var foundUser = await _userService.GetByIdAsync(user.Id, true, HttpContext.RequestAborted) ?? 
            throw new InvalidOperationException();

        return Ok(await _userService.UpdateAsync(user, true, HttpContext.RequestAborted));
    }

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteAsync([FromRoute] Guid id) =>
        Ok(await _userService.DeleteByIdAsync(id, true, HttpContext.RequestAborted));
}
