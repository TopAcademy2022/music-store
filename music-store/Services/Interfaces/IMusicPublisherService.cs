using music_store.Models.Entities;

namespace music_store.Services.Interfaces
{

	/*! 
	* @brief Add method for adding music publishers.
	*/
	public interface IMusicPublisherService
	{
		/*!
		 * @brief Method to add a music publisher.
		 * @param[in] musicPublisher - The music publisher object.
		 * @return True - if the addition was successful; False - otherwise.
		 */
		public bool AddMusicPublisher(MusicPublisher musicPublisher);
	}
