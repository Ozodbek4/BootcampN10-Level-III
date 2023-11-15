using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N70.Identity.Application.Common.Identity.Services;

namespace N70.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) =>
            _userService = userService;
    }
}
