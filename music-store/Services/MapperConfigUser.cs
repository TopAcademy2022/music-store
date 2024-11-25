using AutoMapper;
using music_store.Models.Domains;
using music_store.Models.Entities;
using music_store.Services.Interfaces;

namespace music_store.Services
{
	public class MapperConfigUser : AMapperConfig
	{
		public MapperConfigUser()
		{
			CreateMap<User, DUser>().ForMember(dest => dest.Login, act => act.MapFrom(src => src.Login));
		}

		public override IMapper CreateMapper()
		{
			var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperConfigUser> ());
			return config.CreateMapper();
		}
	}
}