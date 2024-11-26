using System;
using music_store.Models.Entities;

namespace music_store.Services.Interfaces
{
    public interface IMusicGenereService
    {
        public bool AddMusicGenre(MusicGenre genere);

    }
}
