using music_store.Models.Entities;

namespace music_store.Services.Interfaces
{
	/**
	 * @interface IMusicBand
	 * @brief Interface for working with music bands.
	 */
	public interface IMusicBandServise
	{
		/**
		 * @brief Adds a music band.
		 *
		 * @param musicBand The music band object to be added.
		 * @return True if the operation is successful, otherwise False.
		 */
		public bool AddMusicBand(MusicBand musicBand);
	}
}