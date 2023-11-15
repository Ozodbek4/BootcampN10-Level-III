using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N70.Identity.Application.Common.Identity.Services;

namespace N70.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) =>
            _authService = authService;
    }
}
