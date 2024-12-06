using music_store.Models.Entities;

namespace music_store.Models.Domains
{
	public class DTOAsideRecord
	{
		public VinylRecord VinylRecord { get; set; } = null!;

		public User User { get; set; } = null!;
	}
}