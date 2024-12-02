using System;
using System.Linq;
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

		public IEnumerable<VinylRecord>? FindVinylRecordByAuthorName(string authorName)
		{
			try
			{
				return this._dbConnection.VinylRecords.Where(vin => 
				vin.MusicBand.Name.ToLower() == authorName.ToLower());
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return null;
		}
	}
}
