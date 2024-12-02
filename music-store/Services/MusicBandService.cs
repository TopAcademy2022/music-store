using System;
using System.Linq;
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
		private readonly ADatabaseConnection _databaseConnection;

		public MusicBandService(ADatabaseConnection databaseConnection)
		{
            _databaseConnection = databaseConnection;
		}

		public bool AddMusicBand(MusicBand musicBand)
		{
			try
			{
                _databaseConnection.MusicBands.Add(musicBand);
                _databaseConnection.SaveChanges();

				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

			return false;
		}

        public MusicBand? FindMusicBand(MusicBand musicBand)
        {
            try
            {
                return this._databaseConnection.MusicBands.Where(mband =>
                mband.Name == musicBand.Name).FirstOrDefault();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }

            return null;
        }

        public bool DeleteMusicBand(MusicBand musicBand)
        {
            try
            {
                MusicBand? findedMusicBand = this.FindMusicBand(musicBand);

                if (findedMusicBand != null)
                {
                    this._databaseConnection.MusicBands.Remove(findedMusicBand);
                    this._databaseConnection.SaveChanges();


                    return true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }

            return false;
        }
    }
}