using System;
using System.Collections.Generic;
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

		/*! 
		* @brief Get vinyl records by music genre from database.
        * @param[in] string musicGenre - Name of music genre for searching.
        * @return Collection of vinyl records.
        */
		public IEnumerable<VinylRecord> FindVinylRecordsByMusicGenere(string musicGenre);
	}
}
