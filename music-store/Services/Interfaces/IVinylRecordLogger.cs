namespace music_store.Services.Interfaces
{
	public interface IVinylRecordLogger
	{
		void LogChange(string propertyName, object oldValue, object newValue);
	}
}