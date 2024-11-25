using AutoMapper;
using music_store.Models.Domains;
using music_store.Models.Entities;
using music_store.Services.Interfaces;

namespace music_store.Services
{
	public class MapperConfigPurchase : AMapperConfig
	{
		public MapperConfigPurchase()
		{
			CreateMap<PurchaseHistory, PurchasedRecords>().ForMember(dest => dest.User, act => act.MapFrom(src => src.User))
				.ForMember(dest => dest.VinylRecord, act => act.MapFrom(src => src.VinylRecord));
		}

		public override IMapper CreateMapper()
		{
			var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperConfigPurchase>());
			return config.CreateMapper();
		}
	}
}
