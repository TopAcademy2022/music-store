using System;
using System.IO;
using System.Reflection;
using Serilog;

namespace music_store.Services
{
	public class Logger
	{
		private readonly ILogger _logger;

		public Logger()
		{
			string directoryLog = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

			if (!Directory.Exists(directoryLog))
			{
				Directory.CreateDirectory(directoryLog);
			}

			// Initialize serilog
			Log.Logger = new LoggerConfiguration()
				.WriteTo.File(Path.Combine(directoryLog, "changes.log"), rollingInterval: RollingInterval.Day)
				.CreateLogger();

			_logger = Log.Logger;
		}

		public void LogChanges<T>(T original, T changed)
		{
			Type type = typeof(T);

			foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
			{
				if (property.CanWrite)
				{
					object? originalValue = property.GetValue(original);
					object? changedValue = property.GetValue(changed);

					if (!Equals(originalValue, changedValue))
					{
						_logger.Information("Property '{Property}' changed from '{Original}' to '{Updated}'",
							property.Name, originalValue, changedValue);
					}
				}
			}
		}
	}
}