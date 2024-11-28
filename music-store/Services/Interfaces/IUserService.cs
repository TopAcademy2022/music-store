using music_store.Models.Entities;

namespace music_store.Services.Interfaces
{
	public interface IUserService
	{
		public bool AddUser(User user);

		public User? FindUser(User user);

		public bool DeleteUser(User user);

		/*! 
		 * @brief Hashes a password with SHA3-512 and appends a predefined salt, then hashes the resulting string.
		 * @param[in] password The plain text password to be hashed.
		 * @return The final hashed password as a hexadecimal string.
		 */
		public string HashString(string password);
	}
}