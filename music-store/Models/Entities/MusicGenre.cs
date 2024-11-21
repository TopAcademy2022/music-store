namespace music_store.Models.Entities
{
	public class MusicGenre
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public override string ToString()
		{
			return Name;
		}
	}
}
