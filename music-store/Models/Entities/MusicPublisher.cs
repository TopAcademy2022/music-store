using Microsoft.Extensions.Logging;

namespace music_store.Models.Entities
{
	public class MusicPublisher : BaseModel
	{
        public MusicPublisher(ILogger? logger) : base(logger) {}

        public int Id { get; set; }

		public string Name { get; set; } = null!;
	}
}
