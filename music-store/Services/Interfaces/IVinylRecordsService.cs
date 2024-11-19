using music_store.Models.Entities;

namespace music_store.Services.Interfaces
{
	public interface IVinylRecordsService
	{
		/*! 
		* @brief Adding plates to our database.
		*/
		public bool AddVinilRecord(VinylRecord vinylRecord);
	}
}