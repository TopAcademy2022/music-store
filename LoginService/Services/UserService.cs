using LoginService.Models.Domain.Entity;
using LoginService.Services.Interfaces;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LoginService.Services
{
    public class UserService : IUserService
    {
        private DatabaseContext.DatabaseContext _databaseContext;

        private bool ContainsUser(IEnumerable<User> collection, User searchedUser)
        {
            foreach(User user in collection)
            {
                if (user.Id == searchedUser.Id &&
                    user.Login == searchedUser.Login &&
                    user.Password == searchedUser.Password)
                {
                    return true;
                }
            }

            return false;
        }

        public UserService(DatabaseContext.DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public string? CreateHashPassword(string? originalPassword)
        {
            if (originalPassword != null)
            {
                byte[] origin = Encoding.ASCII.GetBytes(originalPassword);

                SHA512 shaM = new SHA512Managed();
                byte[] result = shaM.ComputeHash(origin);

                return Encoding.ASCII.GetString(result);
            }

            return null;
        }

        public bool AddUser(User user)
        {
            if (!this.ContainsUser(this._databaseContext.Set<User>().ToList(), user))
            {
                this._databaseContext.Set<User>().Add(user);
                this._databaseContext.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this._databaseContext.Set<User>().ToList();
        }

        public IEnumerable<User> GetAllUsersByLogin(string? login)
        {
            return this._databaseContext.Set<User>().Where(user => user.Login == login).ToList();
        }
    }
}
