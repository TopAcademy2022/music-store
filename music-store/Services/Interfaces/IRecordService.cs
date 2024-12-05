using music_store.Models.Domains;

namespace music_store.Services.Interfaces
{
	public interface IRecordService
	{
		/*! 
	   * @brief Constructor for RecordService.
	   * @param db - Instance of ADatabaseConnection for database operations.
	   */
		void ReserveRecord(DTOBasketForRecords dto);
	}
}