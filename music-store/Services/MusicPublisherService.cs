using music_store.Models.Entities;
using music_store.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace music_store.Services
{
    /*! 
       * @brief Add method for adding music publishers.
       */
    internal class MusicPublisherService:ImusicPublisherService
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
}
