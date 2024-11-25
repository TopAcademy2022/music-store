using System;
using music_store.Models.Entities;
using music_store.Services.Interfaces;


namespace music_store.Services
{
    public class MusicGenereService : IMusicGenereService
    {
        private ADatabaseConnection _DatabaseConnection;

        public MusicGenereService(ADatabaseConnection databaseConnection)
        {
            this._DatabaseConnection = databaseConnection;
        }
        public bool AddMusicGenre(MusicGenre genere)
        {
            try
            {
                this._DatabaseConnection.MusicGenres.Add(genere);
                this._DatabaseConnection.SaveChanges();

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