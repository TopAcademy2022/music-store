namespace music_store.Models.Entities
{
	public class AsideRecord
	{
		public int Id { get; set; }

		public VinylRecord VinylRecord { get; set; } = null!;

		public User User { get; set; } = null!;
	}
}