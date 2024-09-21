using MediatR;
using System.Text.Json.Serialization;

namespace Shopii.Domain.Commands.v1.Users.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserCommandResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
