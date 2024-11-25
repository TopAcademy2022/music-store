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
	}
}