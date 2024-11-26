using System;

namespace music_store.Models.Entities
{
	public class VinylRecord
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public MusicBand MusicBand { get; set; } = null!;

		public MusicPublisher MusicPublisher { get; set; } = null!;

		public uint TrackCount { get; set; }

		public MusicGenre MusicGenre { get; set; } = null!;

		public DateTime PublicationYear { get; set; }

		public uint CostPrice { get; set; }

		public uint SellingPrice { get; set; }

		public DateTime DateOfReceiptOfTheRecords { get; set; }
	}
}