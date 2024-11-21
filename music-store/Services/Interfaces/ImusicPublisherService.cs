using music_store.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace music_store.Services.Interfaces
{
    public interface ImusicPublisherService
       
    {
        public bool AddMusicPublisher(MusicPublisher musicPublisher);
    }
}
