using System;
using music_store.Models.Entities;
using music_store.Services.Interfaces;

namespace music_store.Services
{
   
    public class MusicPublisherService : IMusicPublisherService
    {

        private ADatabaseConnection _databaseConnection;

        public MusicPublisherService(ADatabaseConnection aDatabaseConnection)
        {
            this._databaseConnection = aDatabaseConnection;
        }

        public bool AddMusicPublisher(MusicPublisher musicPublisher)
        {
            try
            {
                this._databaseConnection.MusicPublishers.Add(musicPublisher);
                this._databaseConnection.SaveChanges();

                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }

            return false;
        }
    }

}

