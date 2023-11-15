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

        public AccountController(IAccountService accountService) =>
            _accountService = accountService;
    }
}
