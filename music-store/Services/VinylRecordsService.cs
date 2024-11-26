using System;
using System.Linq;
using music_store.Services.Interfaces;
using music_store.Models.Entities;

namespace music_store.Services
{
	/*! @class VinylRecordsService
	 *  @brief Service for managing vinyl records in the music store.
	 */
	public class VinylRecordsService : IVinylRecordsService
	{
		/*! @var _dbConnection
		 *  @brief Database connection used by the service.
		 */
		private ADatabaseConnection _dbConnection; //!< Database connection

		public VinylRecordsService(ADatabaseConnection dbConnection)
		{
			this._dbConnection = dbConnection;
		}

		public bool AddVinilRecord(VinylRecord vinylRecord)
		{
			try
			{
				this._dbConnection.VinylRecords.Add(vinylRecord);
				this._dbConnection.SaveChanges();

				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return false;
		}

		public VinylRecord? SearchByName(string vinylRecordName)
		{
			return _dbConnection.VinylRecords
					   .Where(vr => vr.Name == vinylRecordName)
					   .FirstOrDefault();
		}
	}
}