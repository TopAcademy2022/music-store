using System;
using music_store.Models.Entities;
using music_store.Services.Interfaces;

namespace music_store.Services
{
	/*!
	 * @class ServiceMusicBand
	 * @brief Class for working with music bands.
	 */
	public class MusicBandService
	{
		/*!
		 * @brief Method to add a music band.
		 * @param[in] musicBand - The music band object.
		 * @return True - if the addition was successful; False - otherwise .
		 */
		private readonly ADatabaseConnection _db;

        public MusicBandService(ADatabaseConnection db)
        {
            _db = db;
        }

        public bool AddMusicBand(MusicBand musicBand)
		{
			try
			{
				_db.MusicBands.Add(musicBand);
				_db.SaveChanges();

				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

			return false;
		}
	}
}