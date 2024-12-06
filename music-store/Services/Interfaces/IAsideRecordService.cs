using music_store.Models.Entities;

namespace music_store.Services.Interfaces
{
	public interface IAsideRecordService
	{
		public void AddAsideRecord(string vinylRecordName, User user);
	}
}