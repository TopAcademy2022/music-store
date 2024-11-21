using System;
using System.IO;

namespace music_store.Models.Entities
{
	public class VinylRecord
	{
		private static readonly string LogFilePath = "Logs/changes.log";

		public int Id { get; set; }

		private string _name = null!;
		public string Name
		{
			get => _name;
			set
			{
				if (_name != value)
				{
					LogChange(nameof(Name), _name, value);
					_name = value;
				}
			}
		}

		private MusicBand _musicBand = null!;
		public MusicBand MusicBand
		{
			get => _musicBand;
			set
			{
				if (_musicBand != value)
				{
					LogChange(nameof(MusicBand), _musicBand?.ToString() ?? "null", value?.ToString() ?? "null");
					_musicBand = value;
				}
			}
		}

		private MusicPublisher _musicPublisher = null!;
		public MusicPublisher MusicPublisher
		{
			get => _musicPublisher;
			set
			{
				if (_musicPublisher != value)
				{
					LogChange(nameof(MusicPublisher), _musicPublisher?.ToString() ?? "null", value?.ToString() ?? "null");
					_musicPublisher = value;
				}
			}
		}

		private uint _trackCount;
		public uint TrackCount
		{
			get => _trackCount;
			set
			{
				if (_trackCount != value)
				{
					LogChange(nameof(TrackCount), _trackCount.ToString(), value.ToString());
					_trackCount = value;
				}
			}
		}

		private MusicGenre _musicGenre = null!;
		public MusicGenre MusicGenre
		{
			get => _musicGenre;
			set
			{
				if (_musicGenre != value)
				{
					LogChange(nameof(MusicGenre), _musicGenre?.ToString() ?? "null", value?.ToString() ?? "null");
					_musicGenre = value;
				}
			}
		}

		private DateTime _publicationYear;
		public DateTime PublicationYear
		{
			get => _publicationYear;
			set
			{
				if (_publicationYear != value)
				{
					LogChange(nameof(PublicationYear), _publicationYear.ToString("yyyy"), value.ToString("yyyy"));
					_publicationYear = value;
				}
			}
		}

		private uint _costPrice;
		public uint CostPrice
		{
			get => _costPrice;
			set
			{
				if (_costPrice != value)
				{
					LogChange(nameof(CostPrice), _costPrice.ToString(), value.ToString());
					_costPrice = value;
				}
			}
		}

		private uint _sellingPrice;
		public uint SellingPrice
		{
			get => _sellingPrice;
			set
			{
				if (_sellingPrice != value)
				{
					LogChange(nameof(SellingPrice), _sellingPrice.ToString(), value.ToString());
					_sellingPrice = value;
				}
			}
		}

		/*!
		 *	@brief Saves the changes to file
		 *	param[in] propertyName - Name of the column
		 *	param[in] oldValue - old value of column
		 *	param[in] newValue - new value of column
		 */
		private static void LogChange(string propertyName, string oldValue, string newValue)
		{
			Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath) ?? string.Empty);

			var logEntry = $"{DateTime.Now} Property '{propertyName}' changed from '{oldValue}' to '{newValue}'{Environment.NewLine}";
			File.AppendAllText(LogFilePath, logEntry);
		}  
	}
}
