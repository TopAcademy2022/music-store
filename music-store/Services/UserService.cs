using System;
using music_store.Models.Entities;
using music_store.Services.Interfaces;

namespace music_store.Services
{
	public class UserService : IUserService
	{
		private ADatabaseConnection _databaseConnection;

		public UserService(ADatabaseConnection aDatabaseConnection)
		{
			this._databaseConnection = aDatabaseConnection;
		}

		public bool AddUser(User user)
		{
			try
			{
				this._databaseConnection.Users.Add(user);
				this._databaseConnection.SaveChanges();

				return true;
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return false;
		}
	}
}
