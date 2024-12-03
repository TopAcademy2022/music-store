using Microsoft.Extensions.Logging;

namespace music_store.Models.Entities
{
	public class MusicBand : BaseModel
	{
        public MusicBand(ILogger? logger) : base(logger) {}

        public int Id { get; set; }

		public string Name { get; set; } = null!;	
	}
}
