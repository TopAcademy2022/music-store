using System;
using music_store.Services.Interfaces;
using music_store.Models.Entities;

namespace music_store.Services
{
	public class VinylRecordsService : IVinylRecordsService
	{
		private ADatabaseConnection _dbConnection; //!< Database connection

		public VinylRecordsService(SqliteConnection dbConnection)
		{
			this._dbConnection = dbConnection;
		}

		/*!
		* @brief Adding plates to our database.
		* @param[in] vinylRecord class instance to add.
		* @return True - Vinyl Record added; False - vinylRecord not added.
		*/
		public bool AddVinilRecord(VinylRecord vinylRecord)
		{
			try
			{
				this._dbConnection.VinylRecords.Add(vinylRecord); //!< Adding a change to our data
				this._dbConnection.SaveChanges();

				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return false;
		}
	}
}