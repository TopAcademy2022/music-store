using music_store.Models.Domains;
using music_store.Models.Entities;
using music_store.Models.Enum;
using music_store.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace music_store.Services
{
	public class RecordDiscountService<T> : IRecordDiscountService<T>
	{
		private ADatabaseConnection _databaseConnection;

		private IFactoryMapper _factoryMapper;

		public RecordDiscountService(ADatabaseConnection aDatabaseConnection, IFactoryMapper factoryMapper)
		{
			this._factoryMapper = factoryMapper;

			this._databaseConnection = aDatabaseConnection;
		}

		public bool AddDiscount(T objectClass, uint priceDiscount, string name, DateTime TimeStart, DateTime TimeEnd)
		{
			Сategory сategory;

			try
			{
				switch (Convert.ToString(objectClass.GetType()))
				{
					case "User":

						сategory = Сategory.User;

						break;

					case "ReleaseTime":

						сategory = Сategory.ReleaseTime;

						break;

					case "Genre":

						сategory = Сategory.Genre;

						break;

					case "Author":

						сategory = Сategory.Author;

						break;
					default:
						сategory = Сategory.Null;

						break;
				}

				RecordDiscount recordDiscount = new RecordDiscount()
				{
					Category = сategory,
					DiscountPercentage = priceDiscount,
					Name = name,
					DiscountStart = TimeStart,
					DiscountEnd = TimeEnd
				};

				this._databaseConnection.RecordDiscounts.Add(recordDiscount);
				this._databaseConnection.SaveChanges();

				return true;

			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return false;
		}

		public uint CheckDiscount(Сategory category, int objectId)
		{
			List<ActiveDiscounts> activeDiscounts = new List<ActiveDiscounts>();

			foreach (var discounts in this._databaseConnection.RecordDiscounts)
			{
				activeDiscounts.Add(this._factoryMapper.GetMapperConfig().CreateMapper().Map<ActiveDiscounts>(discounts));  //!< Data entry into the domain model.
			}

			ActiveDiscounts? currentDiscount = activeDiscounts.Where(discount => discount.Category == category && discount.ObjectDiscount == objectId).FirstOrDefault();

			if (currentDiscount != null)
			{
				return currentDiscount.DiscountPercentage;
			}

			return 0;
		}
	}
}