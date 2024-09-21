using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopii.Domain.Commands.v1.Users.CreateUser;
using Shopii.Domain.Commands.v1.Users.LoginUser;

namespace Shopii.API.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        public IMediator Mediator { get; set; }
        public ILogger Logger { get; set; }

        public UserController(
            IMediator mediator,
            ILoggerFactory logger)
        {
            Mediator = mediator;
            Logger = logger.CreateLogger<UserController>();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand request)
        {
            try
            {
                var result = await Mediator.Send(request);
                return Created(result.Id, result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromHeader] string username, string password)
        {
            try
            {
                var result = await Mediator.Send(new LoginUserCommand() { Username = username, Password = password });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
