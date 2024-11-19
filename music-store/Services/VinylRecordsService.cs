using System;
using music_store.Services.Interfaces;
using music_store.Models.Entities;

namespace music_store.Services
{
	public class VinylRecordsService : IVinylRecordsService
	{
		private ADatabaseConnection _dbConnection; //!< Database connection

		public VinylRecordsService()
		{
			this._dbConnection = new SqliteConnection();
		}

		/*!
		* @brief Adding plates to our database.
		* @param[in] vinylRecord class instance to add.
		* @return True - vinylRecord  added; False - vinylRecord not added.
		*/
		public bool AddVinilRecord(VinylRecord vinylRecord)
		{
			try
			{
				this._dbConnection.VinylRecords.Add(vinylRecord); //!< Adding a change to our data
				this._dbConnection.SaveChanges(); //!< Save changes to our data

				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message); //!< Exception output
			}

			return false;
		}
	}
}