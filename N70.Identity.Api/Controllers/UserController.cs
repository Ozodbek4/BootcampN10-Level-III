using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using N70.Identity.Application.Common.Identity.Models;
using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Domain.Entities;

namespace N70.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService) =>
            _userService = userService;

        [HttpGet("{id:Guid")]
        public async ValueTask<IActionResult> Get([FromRoute] Guid id) =>
            Ok(await _userService.GetByIdAsync(id, true, HttpContext.RequestAborted));

        [HttpPatch]
        public async ValueTask<IActionResult> Create([FromBody] RegisterDetails registerDetails) =>
            Ok(await _accountService.CreateUserAsync(_mapper.Map<User>(registerDetails)));

        [HttpPut("{id:Guid")]
        public async ValueTask<IActionResult> Update([FromRoute] Guid id, [FromBody] RegisterDetails registerDetails)
        {
            var found = await _userService.GetByIdAsync(id, true);
            var mapUser = _mapper.Map(registerDetails, found)!;

            return Ok(await _userService.UpdateAsync(mapUser, cancellationToken: HttpContext.RequestAborted));
        }

        [HttpDelete("{id:Guid")]
        public async ValueTask<IActionResult> Delete([FromRoute] Guid id) =>
            Ok(await _userService.DeleteAsync(id, cancellationToken: HttpContext.RequestAborted));
    }
}
