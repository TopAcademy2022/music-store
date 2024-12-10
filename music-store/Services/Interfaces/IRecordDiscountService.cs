using music_store.Models.Entities;
using music_store.Models.Enum;
using System;

namespace music_store.Services.Interfaces
{
	public interface IRecordDiscountService<T>
	{
		public bool AddDiscount(T objectClass, uint priceDiscount, string name, DateTime TimeStart, DateTime TimeEnd);

		public uint CheckDiscount(Сategory category, int objectId);
	}
}
