using System;
using music_store.Models.Domains;
using music_store.Models.Entities;
using music_store.Services.Interfaces;

namespace music_store.Services
{
	public class RecordService : IRecordService
	{
		private readonly ADatabaseConnection _db;

		public RecordService(ADatabaseConnection db)
		{
			_db = db;
		}

		/*! 
	  * @brief Reserves a vinyl record for a user.
	  * @param dto - Data Transfer Object containing record and user IDs.
	  * @throws Exception if the vinyl record or user is not found.
	  */
		public void ReserveRecord(DTOBasketForRecords dto)
		{
			var vinylRecord = _db.VinylRecords.Find(dto.VinylRecordId);
			var user = _db.Users.Find(dto.UserId);

			if (vinylRecord == null || user == null)
			{
				throw new Exception("Виниловая пластинка или пользователь не найдены.");
			}

			var basketEntry = new BasketForRecords
			{
				VinylRecord = vinylRecord,
				User = user
			};

			_db.BasketForRecords.Add(basketEntry);
			_db.SaveChanges();
		}
	}
}