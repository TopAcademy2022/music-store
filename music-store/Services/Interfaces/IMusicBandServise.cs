using music_store.Models.Entities;

namespace music_store.Services.Interfaces
{
	/*!
	 * @interface IMusicBand
	 * @brief Interface for working with music bands.
	 */
	public interface IMusicBandServise
	{
		public bool AddMusicBand(MusicBand musicBand);
	}
}