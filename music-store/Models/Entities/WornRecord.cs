using System;
using System.Collections.Generic;
using System.Text;

namespace music_store.Models.Entities
{
    public class WornRecord
    {
        public int Id { get; set; }

        public VinylRecord VinylRecord { get; set; } = null!;

        public DateTime DateOfRetirement { get; set; }
    }
}
