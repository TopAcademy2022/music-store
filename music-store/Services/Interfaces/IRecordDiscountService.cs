using music_store.Models.Entities;
using System;

namespace music_store.Services.Interfaces
{
	public interface IRecordDiscountService<T>
	{
		public bool AddDiscount(T objectClass, uint priceDiscount, string name, DateTime TimeStart, DateTime TimeEnd);

		public bool CheckDiscountRecord(User user);

		public bool CheckDiscountUser(VinylRecord vinylRecord);


	}
}
