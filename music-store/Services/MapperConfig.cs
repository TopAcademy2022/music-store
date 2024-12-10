using System;
using AutoMapper;
using music_store.Models.Domains;
using music_store.Models.Entities;

namespace music_store.Services
{
	public class MapperConfig : Profile
	{
		public static object InitializeAutomapper()
		{
			throw new NotImplementedException();
		}

		/*! 
		* @brief Create map Mapper by field.
		*/
		public MapperConfig()
		{
			CreateMap<User, DomainUser>().ForMember(dest => dest.Login, act => act.MapFrom(src => src.Login));
			CreateMap<PurchaseHistory, PurchasedRecords>().ForMember(dest => dest.User, act => act.MapFrom(src => src.User))
					.ForMember(dest => dest.VinylRecord, act => act.MapFrom(src => src.VinylRecord));
            CreateMap<RecordDiscount, ActiveDiscounts>().ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
					.ForMember(dest => dest.DiscountPercentage, act => act.MapFrom(src => src.DiscountPercentage))
					.ForMember(dest => dest.Category, act => act.MapFrom(src => src.Category))
					.ForMember(dest => dest.DiscountEnd <= DateTime.Now, act => act.MapFrom(src => src.DiscountEnd))
					.ForMember(dest => dest.DiscountStart >= DateTime.Now, act => act.MapFrom(src => src.DiscountStart));
			CreateMap<AsideRecord, DTOAsideRecord>()
				.ForMember(dest => dest.User, act => act.MapFrom(src => src.User))
				.ForMember(dest => dest.VinylRecord, act => act.MapFrom(src => src.VinylRecord));
			CreateMap<DTOAsideRecord, AsideRecord>()
			  .ForMember(dest => dest.User, act => act.MapFrom(src => src.User))
			  .ForMember(dest => dest.VinylRecord, act => act.MapFrom(src => src.VinylRecord));
		}

        /*! 
		* @brief Create Configuration Mapper.
		* @return IMapper - Mapper Configuration.
		*/
		public IMapper CreateMapper()
		{
			var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperConfig>());
			return config.CreateMapper();
		}
	}
}