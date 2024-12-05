using music_store.Models.Enum;
using System;

namespace music_store.Models.Entities
{
	public class RecordDiscount
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public Сategory Category { get; set; }

		public uint discountPrice { get; set; }

		public DateTime discountStart { get; set; }

		public DateTime discountEnd { get; set; }
	}
}
