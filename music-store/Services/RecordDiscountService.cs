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
			Сategory сategory = Сategory.Null;

			try
			{
				switch (Convert.ToString(objectClass.GetType()))
				{
					case "User":

						сategory = Сategory.User;

						break;

					case "ReleaseTime":

						сategory = Сategory.Genre;

						break;

					case "Genre":

						сategory = Сategory.Genre;

						break;

					case "Author":

						сategory = Сategory.Author;

						break;
					default:

						break;
				}

				RecordDiscount recordDiscount = new RecordDiscount()
				{
					Category = сategory,
					discountPrice = priceDiscount,
					Name = name,
					discountStart = TimeStart,
					discountEnd = TimeEnd
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

		public bool CheckDiscountUser(VinylRecord vinylRecord)
		{
			if (vinylRecord.RecordDiscount != null && vinylRecord.RecordDiscount.discountStart > DateTime.Now
							&& vinylRecord.RecordDiscount.discountEnd < DateTime.Now)
			{
				return true;
			}

			return false;
		}

		public bool CheckDiscountRecord(User user)
		{
			if (user.RecordDiscount != null && user.RecordDiscount.discountStart > DateTime.Now
							&& user.RecordDiscount.discountEnd < DateTime.Now)
			{
				return true;
			}

			return false;
		}

	}
}