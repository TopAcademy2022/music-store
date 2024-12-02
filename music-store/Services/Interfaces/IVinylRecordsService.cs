using music_store.Models.Entities;

namespace music_store.Services.Interfaces
{
	public interface IVinylRecordsService
	{
		/*! 
		* @brief Adding plates to our database.
		* @param[in] vinylRecord - class instance to add.
		* @return True - vinyl record added; False - vinyl record not added.
		*/
		public bool AddVinilRecord(VinylRecord vinylRecord);
		/*! 
		* @brief finding a record by name in our database.
		* @param[in] authorName - string to find in database.
		* @return VinylRecord - author`s name found; Null - author`s name not found.
		*/
		public IEnumerable<VinylRecord>? FindVinylRecordByAuthorName(string authorName);
	}
}
