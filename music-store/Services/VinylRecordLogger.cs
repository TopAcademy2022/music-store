using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using music_store.Services.Interfaces;

namespace music_store.Services
{
	public class VinylRecordLogger : IVinylRecordLogger
	{
		private readonly ILogger<VinylRecordLogger> _logger;

		private static readonly string LogFilePath = "Logs/changes.log";

		public VinylRecordLogger(ILogger<VinylRecordLogger>? logger = null)
		{
			_logger = logger ?? CreateDefaultLogger();
		}

		public void LogChange(string propertyName, object oldValue, object newValue)
		{
			Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath) ?? string.Empty);

			string logMessage = $"{DateTime.Now}: Property '{propertyName}' changed from '{oldValue ?? "null"}' to '{newValue ?? "null"}'";

			_logger.LogInformation(logMessage);

			File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
		}

		private static ILogger<VinylRecordLogger> CreateDefaultLogger()
		{
			var serviceProvider = new ServiceCollection()
				.AddLogging(builder => builder.ClearProviders())
				.BuildServiceProvider();

			var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
			return loggerFactory.CreateLogger<VinylRecordLogger>();
		}
	}
}
