using System.Collections.Generic;
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
		*  @brief Searches for a vinyl record by its name.
		*  @param[in] vinylRecordName - The name of the vinyl record to search for.
		*  @return The first matching vinyl record found, or null if no match is found.
		*/
		public VinylRecord? SearchByName(string searchTerm);

		/*! 
		* @brief Retrieves a list of newly added vinyl records from the last month.
		* @return A list of vinyl records that were added to the database within the last month.
		*/
		public List<VinylRecord> GetNewVinylRecords();
	}
}