namespace LoginService.Models.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public SecurityGroup SecurityGroup { get; set; } = null!;
    }
}
