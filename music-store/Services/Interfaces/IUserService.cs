using music_store.Models.Entities;

namespace music_store.Services.Interfaces
{
	public interface IUserService
	{
		public bool AddUser(User user);

		public User? FindUser(User user);

		public bool DeleteUser(User user);
	}
}
