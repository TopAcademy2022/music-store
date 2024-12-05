using System;
using music_store.Models.Entities;
using music_store.Services.Interfaces;

namespace music_store.Services
{
    public class MusicGenereService : IMusicGenereService
    {
        private ADatabaseConnection _databaseConnection;

        public MusicGenereService(ADatabaseConnection databaseConnection)
        {
            this._databaseConnection = databaseConnection;
        }
        
        public bool AddMusicGenre(MusicGenre genere)
        {
            try
            {
                this._databaseConnection.MusicGenres.Add(genere);
                this._databaseConnection.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
    }
}
