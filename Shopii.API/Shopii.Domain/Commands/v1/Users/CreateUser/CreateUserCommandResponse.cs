namespace Shopii.Domain.Commands.v1.Users.CreateUser
{
    public class CreateUserCommandResponse
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
