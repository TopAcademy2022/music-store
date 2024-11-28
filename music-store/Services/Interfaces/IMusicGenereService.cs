using System;
using music_store.Models.Entities;

namespace music_store.Services.Interfaces
{
    public interface IMusicGenereService
    {
        /*! 
		* @brief Adding genres to our database.
        * @param[in] MusicGenre genere - class instance to add.
        * @return True - music genere added; False - music genere not added.
        */
        public bool AddMusicGenre(MusicGenre genere);
    }
}
