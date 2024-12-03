using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace music_store.Services
{
	public class Logger : Microsoft.Extensions.Logging.ILogger
	{
		private readonly Serilog.ILogger _logger;

		public Logger()
		{
			// Initialize logger
			Serilog.Log.Logger = new LoggerConfiguration()
				.WriteTo.File($"Logs/changes.log", rollingInterval: RollingInterval.Day)
				.CreateLogger();

			_logger = Serilog.Log.Logger;
		}

		//public static void Log(this Microsoft.Extensions.Logging.ILogger logger, LogLevel logLevel, string? message, params object?[] args)
		//{
		//	LogChange(logLevel.ToString(), message);
		//}
		
		/*!
		 * @brief Writes the changes into files
		 * @param[in] propertyName - Name of Property that was changed
		 * @param[in] oldValue - Value before the change
		 * @param[in] newValue - Value after the change
		 */
		public void LogChange(string propertyName, string oldValue, string newValue)
		{
			string logMessage = $"Property '{propertyName}' changed from '{oldValue ?? "null"}' to '{newValue ?? "null"}'";

			_logger.Information(logMessage);
		}

		public IDisposable BeginScope<TState>(TState state)
		{
			throw new NotImplementedException();
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			throw new NotImplementedException();
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			throw new NotImplementedException();
		}
	}
}
