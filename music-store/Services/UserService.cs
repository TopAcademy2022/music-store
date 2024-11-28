﻿using System;
using System.Linq;
using System.Text;
using Org.BouncyCastle.Crypto.Digests;
using music_store.Models.Entities;
using music_store.Services.Interfaces;

namespace music_store.Services
{
	public class UserService : IUserService
	{
		private ADatabaseConnection _databaseConnection;

		private const string _salt = "34KFEB4466JVVNN443JJ25J66564J4N685NN";

		public UserService(ADatabaseConnection aDatabaseConnection)
		{
			this._databaseConnection = aDatabaseConnection;
		}

		public bool AddUser(User user)
		{
			try
			{
				User? findedUser = this.FindUser(user);

				if (findedUser == null)
				{
					this._databaseConnection.Users.Add(user);
					this._databaseConnection.SaveChanges();

					return true;
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return false;
		}

		public User? FindUser(User user)
		{
			try
			{
				return this._databaseConnection.Users.Where(usr =>
				usr.Login == user.Login &&
				usr.Password == user.Password).FirstOrDefault();
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return null;
		}

		public bool DeleteUser(User user)
		{
			try
			{
				User? findedUser = this.FindUser(user);

				if (findedUser != null)
				{
					this._databaseConnection.Users.Remove(findedUser);
					this._databaseConnection.SaveChanges();

					return true;
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return false;
		}

		public string HashString(string password)
		{
			var sha3 = new Sha3Digest(512);

			byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

			sha3.BlockUpdate(passwordBytes, 0, passwordBytes.Length);
			byte[] hashBytes = new byte[sha3.GetDigestSize()];
			sha3.DoFinal(hashBytes, 0);

			var saltedPasswordBytes = new byte[hashBytes.Length + Encoding.UTF8.GetByteCount(_salt)];
			Buffer.BlockCopy(hashBytes, 0, saltedPasswordBytes, 0, hashBytes.Length);
			Buffer.BlockCopy(Encoding.UTF8.GetBytes(_salt), 0, saltedPasswordBytes, hashBytes.Length, Encoding.UTF8.GetByteCount(_salt));

			sha3.BlockUpdate(saltedPasswordBytes, 0, saltedPasswordBytes.Length);
			byte[] finalHashBytes = new byte[sha3.GetDigestSize()];
			sha3.DoFinal(finalHashBytes, 0);

			var finalHashString = new StringBuilder(finalHashBytes.Length * 2);
			foreach (byte b in finalHashBytes)
			{
				finalHashString.AppendFormat("{0:x2}", b);
			}
			return finalHashString.ToString();
		}
	}
}