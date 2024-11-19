using Microsoft.EntityFrameworkCore;
using music_store.Services.Interfaces;

namespace music_store.Services
{
	public class SqliteConnection : ADatabaseConnection
	{
		private const string _DATABASE_NAME = "production.db";

		protected override string ReturnConnectionString()
		{
			return $"Data Source={_DATABASE_NAME}";
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(this.ConnectionString);
		}
	}
}
