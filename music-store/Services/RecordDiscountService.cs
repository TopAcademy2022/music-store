using music_store.Models.Domains;
using music_store.Models.Entities;
using music_store.Models.Enum;
using music_store.Services.Interfaces;
using System;

namespace music_store.Services
{
	public class RecordDiscountService<T> : IRecordDiscountService<T>
	{
		private ADatabaseConnection _databaseConnection;

		public RecordDiscountService(ADatabaseConnection aDatabaseConnection) => this._databaseConnection = aDatabaseConnection;

		public bool AddDiscount(T objectClass, uint priceDiscount, string name, DateTime TimeStart, DateTime TimeEnd )
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

		public bool CheckDiscountRecord(VinylRecord vinylRecord, ActiveDiscounts activeDiscounts)
		{
			if ()
			{
				return true;
			}

			return false;
		}

		public bool CheckDiscountUser(User user)
		{
			if ()
			{
				return true;
			}

			return false;
		}

	}
}