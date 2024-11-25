using music_store.Models.Entities;

namespace music_store.Models.Domains
{
	public class DUser
	{
		public string Login { get; set; } = null!;

		public Balance Wallet { get; set; } = null!;

	}
}