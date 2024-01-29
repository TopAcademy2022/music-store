using System.Collections.Generic;
using LoginService.Models.Domain.Entity;

namespace LoginService.Services.Interfaces
{
    public interface IUserService
    {
        public string? CreateHashPassword(string? originalPassword);

        public bool AddUser(User user);

        public IEnumerable<User> GetAllUsers();

        public IEnumerable<User> GetAllUsersByLogin(string? login);
    }
}
