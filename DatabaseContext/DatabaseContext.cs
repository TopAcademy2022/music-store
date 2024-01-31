using Microsoft.EntityFrameworkCore;

namespace DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        private string? _databaseConnectionString;

        private string? GetConnectionString()
        {
            string result = string.Empty;

            result = @"Server=localhost, 5000;Database=main;Trusted_Connection=True;";

            return result;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(this._databaseConnectionString);
        }

        public DatabaseContext()
        {
            this._databaseConnectionString = this.GetConnectionString();

            if (!String.IsNullOrEmpty(this._databaseConnectionString))
            {
                this.Database.EnsureCreated();
            }
        }
    }
}