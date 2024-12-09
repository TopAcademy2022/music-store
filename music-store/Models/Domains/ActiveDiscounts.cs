using music_store.Models.Entities;
using music_store.Models.Enum;

namespace music_store.Models.Domains
{
    public class ActiveDiscounts
    {
        public string Name { get; set; } = null!;

        public Сategory Category { get; set; }

        public uint DiscountPercentage { get; set; }
    }
}
