namespace music_store.Models.Entities
{
	public class User
	{
		public int Id { get; set; }

		public string Login { get; set; } = null!;

		public string Password { get; set; } = null!;

		public RecordDiscount RecordDiscount { get; set; } = null!;
	}
}
