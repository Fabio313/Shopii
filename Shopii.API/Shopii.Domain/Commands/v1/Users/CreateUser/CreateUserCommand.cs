using MediatR;
using System.Text.Json.Serialization;

namespace Shopii.Domain.Commands.v1.Users.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
