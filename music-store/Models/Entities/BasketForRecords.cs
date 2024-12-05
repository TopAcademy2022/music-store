namespace music_store.Models.Entities
{
	public class BasketForRecords
	{
		public int Id { get; set; }
		public VinylRecord VinylRecord { get; set; } = null!;

		public User User { get; set; } = null!;
	}
}