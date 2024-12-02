using System;
using System.Linq;
using music_store.Services.Interfaces;
using music_store.Models.Entities;
using System.Collections.Generic;


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

		public VinylRecord? SearchByName(string vinylRecordName)
		{
			return _dbConnection.VinylRecords
					   .Where(vr => vr.Name == vinylRecordName)
					   .FirstOrDefault();
		}

		public List<VinylRecord> GetNewVinylRecords()
		{
			DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);
			return _dbConnection.VinylRecords
					   .Where(vr => vr.DateOfReceiptOfTheRecords >= oneMonthAgo)
					   .ToList();
		}

        public bool DeleteVinilRecord(VinylRecord vinylRecord)
        {
            try
            {
                this._dbConnection.VinylRecords.Remove(vinylRecord);
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

