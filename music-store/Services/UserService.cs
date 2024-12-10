using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Org.BouncyCastle.Crypto.Digests;
using music_store.Models.Domains;
using music_store.Models.Entities;
using music_store.Models.Enum;
using music_store.Services.Interfaces;
using Org.BouncyCastle.Bcpg;

namespace music_store.Services
{
	public class UserService<T> : IUserService<T>
	{
		private ADatabaseConnection _databaseConnection;

		private const string _salt = "34KFEB4466JVVNN443JJ25J66564J4N685NN";
    
    	private IFactoryMapper _factoryMapper;

		private IRecordDiscountService<T> _discountService;

		public UserService(ADatabaseConnection aDatabaseConnection, IFactoryMapper factoryMapper, IRecordDiscountService<T> discountService)
    	{
      		this._databaseConnection = aDatabaseConnection;
			this._factoryMapper = factoryMapper;
			this._discountService = discountService;
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
    
		/*! 
		* @brief Buying a record, charging money from the user's balance.
		* @param[in] vinylRecord - purchasable record.
		* @param[in] user - record buyer.
		* @return True - record purchased; False - record not purchased.
		*/
		public bool BuyVinylRecord(User user, VinylRecord vinylRecord)
		{
			DomainUser domainUser = this._factoryMapper.GetMapperConfig().CreateMapper().Map<DomainUser>(user);  //!< Data entry into the domain model.

			try
			{
				if (domainUser.Wallet.BalanceUser >= vinylRecord.CostPrice)
				{
					domainUser.Wallet.BalanceUser -= vinylRecord.CostPrice * (1 - this._discountService.CheckDiscount(Сategory.Vinyl, vinylRecord.Id)); //!< Discounted debit from the balance.

					PurchaseHistory history = new PurchaseHistory() { User = user, VinylRecord = vinylRecord, DatePurchase = DateTime.Now };

					PurchasedRecords records = this._factoryMapper.GetMapperConfig().CreateMapper().Map<PurchasedRecords>(history);  //!< Data entry into the domain model.

					this._databaseConnection.PurchaseHistories.Add(history);
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

		public bool IdentificationUser(DomainUser domainUser)
		{
			List<DomainUser> domainUsers = new List<DomainUser>();

			foreach (var user in this._databaseConnection.Users)
			{
				domainUsers.Add(this._factoryMapper.GetMapperConfig().CreateMapper().Map<DomainUser>(user));  //!< Data entry into the domain model.
			}

			try
			{
				return domainUsers.Any(log => log.Login == domainUser.Login); //!< Checking the presence of elements. 
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return false;
		}

		public bool Registration(string login, string password)
		{
			if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
			{
				User user = new User()
				{
					Login = login,
					Password = this.HashString(password)
				};

				try
				{
					return this.AddUser(user);
				}
				catch (Exception exception)
				{
					Console.WriteLine(exception.ToString());
				}
			}

			return false;
		}

		public bool Authentication(User User)
		{
			try
			{
				var foundUser = this._databaseConnection.Users.FirstOrDefault(usrs => usrs.Login == User.Login);

				if (foundUser != null && foundUser.Password == HashString(User.Password))
				{
					return true;
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return false;
		}
	}
}