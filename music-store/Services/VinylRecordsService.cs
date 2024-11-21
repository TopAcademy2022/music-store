using System;
using music_store.Services.Interfaces;
using music_store.Models.Entities;

namespace music_store.Services
{
	public class VinylRecordsService : IVinylRecordsService
	{
		private ADatabaseConnection _dbConnection; //!< Database connection

		public VinylRecordsService(ADatabaseConnection dbConnection)
		{
			this._dbConnection = dbConnection;
		}

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