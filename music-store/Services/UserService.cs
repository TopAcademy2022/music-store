using System;
using System.Collections.Generic;
using System.Linq;
using music_store.Models.Domains;
using music_store.Models.Entities;
using music_store.Services.Interfaces;

namespace music_store.Services
{
	public class UserService<T> : IUserService<T>
	{
		private ADatabaseConnection _databaseConnection;

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

		public bool BuyVinylRecord(User user, VinylRecord vinylRecord)
		{
			DomainUser domainUser = this._factoryMapper.GetMapperConfig().CreateMapper().Map<DomainUser>(user);  //!< Data entry into the domain model.

			try
			{
				if (domainUser.Wallet.BalanceUser >= vinylRecord.CostPrice)
				{
					domainUser.Wallet.BalanceUser -= vinylRecord.CostPrice * (1 - _discountService.CheckDiscount()); //!< Discounted debit from the balance.
					
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
	}
}