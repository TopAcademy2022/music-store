using Serilog;

namespace music_store.Services
{
	public class Logger
	{
		private readonly ILogger _logger;

		public Logger()
		{
			// Initialize logger
			Log.Logger = new LoggerConfiguration()
				.WriteTo.File($"Logs/changes.log", rollingInterval: RollingInterval.Day)
				.CreateLogger();

			_logger = Log.Logger;
		}

		/*!
		 * @brief Writes the changes into files
		 * @param[in] propertyName - Name of Property that was changed
		 * @param[in] oldValue - Value before the change
		 * @param[in] newValue - Value after the change
		 */
		public void LogChange(string propertyName, object oldValue, object newValue)
		{
			string logMessage = $"Property '{propertyName}' changed from '{oldValue ?? "null"}' to '{newValue ?? "null"}'";

			_logger.Information(logMessage);
		}
	}
}
