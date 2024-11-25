using music_store.Models.Entities;

namespace music_store.Services.Interfaces
{
	/*!
	 * @interface IMusicBand
	 * @brief Interface for working with music bands.
	 */
	public interface IMusicBandService
	{
		/*!
		 * @brief Method to add a music band.
		 * @param[in] musicBand - The music band object.
		 * @return True - if the addition was successful; False - otherwise .
		 */
		public bool AddMusicBand(MusicBand musicBand);
	}
}