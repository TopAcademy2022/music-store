using music_store.Models.Entities;
using System;
using System.Text;
using System.Collections.Generic;

namespace music_store.Services.Interfaces
{

    /*! 
    * @brief Add method for adding music publishers.
    */
    public interface ImusicPublisherService
       
    {
        public bool AddMusicPublisher(MusicPublisher musicPublisher);
    }
}
