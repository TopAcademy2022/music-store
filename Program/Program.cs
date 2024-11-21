using music_store.Models.Entities;

class Program
{
	static void Main(string[] args)
	{
		VinylRecord record = new VinylRecord
		{
			Id = 1,
			Name = "Abbey Road",
			MusicBand = new MusicBand { Name = "The Beatles" },
			MusicPublisher = new MusicPublisher { Name = "EMI" },
			TrackCount = 17,
			MusicGenre = new MusicGenre { Name = "Rock" },
			PublicationYear = new DateTime(1969, 1, 1),
			CostPrice = 500,
			SellingPrice = 1000
		};

		record.Name = "Revolver";
		record.TrackCount = 14;
		record.SellingPrice = 1200;
	}
}