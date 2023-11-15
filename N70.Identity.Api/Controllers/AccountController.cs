using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N70.Identity.Application.Common.Identity.Services;

namespace N70.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPut("verification/{token}")]
        public async ValueTask<IActionResult> VerificateAsync([FromRoute] string token)
        {
            var result = await _accountService.VerificationAsync(token);
            return Ok(result);
        }
    }
}
