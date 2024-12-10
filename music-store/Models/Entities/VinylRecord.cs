using System;
using music_store.Services;

namespace music_store.Models.Entities
{
	public class VinylRecord
	{
		private readonly Logger _logger;

		public VinylRecord(Logger logger)
		{
			_logger = logger;
		}

		public int Id { get; set; }

		private string _name = string.Empty;
		public string Name
		{
			get => _name;
			set
			{
				if (_name != value)
				{
					LogPropertyChange(nameof(Name), _name, value);
					_name = value;
				}
			}
		}

		private MusicBand _musicBand = new MusicBand();
		public MusicBand MusicBand
		{
			get => _musicBand;
			set
			{
				if (_musicBand != value)
				{
					LogPropertyChange(nameof(MusicBand), _musicBand, value);
					_musicBand = value;
				}
			}
		}

		private MusicPublisher _musicPublisher = new MusicPublisher();
		public MusicPublisher MusicPublisher 
		{ 
			get => _musicPublisher; 
			set
			{
				if (_musicPublisher != value)
				{
					LogPropertyChange(nameof(MusicPublisher), _musicPublisher, value);
					_musicPublisher = value;
				}
			}
		}

		private uint _trackCount = 0;
		public uint TrackCount 
		{ 
			get => _trackCount; 
			set
			{
				if (_trackCount != value)
				{
					LogPropertyChange(nameof(TrackCount), _musicGenre, value);
					_trackCount = value;
				}
			}
		}

		private MusicGenre _musicGenre = new MusicGenre();
		public MusicGenre MusicGenre 
		{ 
			get => _musicGenre;
			set
			{
				if (_musicGenre != value)
				{
					LogPropertyChange(nameof(MusicGenre), _musicGenre, value);
					_musicGenre = value;
				}
			}
		}

		private DateTime _publicationYear = DateTime.MinValue;
		public DateTime PublicationYear 
		{
			get => _publicationYear;
			set
			{
				if (_publicationYear != value)
				{
					LogPropertyChange(nameof(PublicationYear), _publicationYear, value);
					_publicationYear = value;
				}
			}
		}

		private uint _costPrice = 0;
		public uint CostPrice
		{
			get => _costPrice;
			set
			{
				if (_costPrice != value)
				{
					LogPropertyChange(nameof(_costPrice), _costPrice, value);
					_costPrice = value;
				}
			}
		}

		private uint _sellingPrice = 0;
		public uint SellingPrice
		{
			get => _sellingPrice;
			set
			{
				if (_sellingPrice != value)
				{
					LogPropertyChange(nameof(_sellingPrice), _sellingPrice, value);
					_sellingPrice = value;
				}
			}
		}

		private DateTime _dateOfReceiptOfTheRecords = DateTime.MinValue;
		public DateTime DateOfReceiptOfTheRecords
		{
			get => _dateOfReceiptOfTheRecords;
			set
			{
				if (_dateOfReceiptOfTheRecords != value)
				{
					LogPropertyChange(nameof(_dateOfReceiptOfTheRecords), _dateOfReceiptOfTheRecords, value);
					_dateOfReceiptOfTheRecords = value;
				}
			}
		}

		private void LogPropertyChange(string propertyName, object? originalValue, object? newValue)
		{
			_logger.LogChanges(originalValue, newValue);
		}

		public bool IsWorn {  get; set; } = false;

		public double WearDegree { get; set; }
	}
}
