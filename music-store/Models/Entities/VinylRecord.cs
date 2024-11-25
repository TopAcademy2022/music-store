using System;
using music_store.Services;
using music_store.Services.Interfaces;

namespace music_store.Models.Entities
{
	public class VinylRecord
	{
		private readonly VinylRecordLogger? _logger;

		public VinylRecord(VinylRecordLogger? logger = null)
		{
			_logger = logger;
		}

		public int Id { get; set; }

		private string _name = null!;
		public string Name
		{
			get => _name;
			set
			{
				if (_name != value)
				{
					_logger?.LogChange(nameof(Name), _name, value);
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
					string oldValue = _musicBand?.Name ?? "null";
					string newValue = value?.Name ?? "null";

					_logger?.LogChange(nameof(MusicBand), oldValue, newValue);
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
					string oldValue = _musicPublisher?.Name ?? "null";
					string newValue = value?.Name ?? "null";

					_logger?.LogChange(nameof(MusicPublisher), oldValue, newValue);
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
					_logger?.LogChange(nameof(TrackCount), _trackCount.ToString(), value.ToString());
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
					string oldValue = _musicGenre?.Name ?? "null";
					string newValue = value?.Name ?? "null";

					_logger?.LogChange(nameof(MusicGenre), oldValue, newValue);
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
					_logger?.LogChange(nameof(PublicationYear), _publicationYear.ToString("yyyy"), value.ToString("yyyy"));
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
					_logger?.LogChange(nameof(CostPrice), _costPrice.ToString(), value.ToString());
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
					_logger?.LogChange(nameof(SellingPrice), _sellingPrice.ToString(), value.ToString());
					_sellingPrice = value;
				}
			}
		}
	}
}
