using music_store.Services.Interfaces;

namespace music_store.Services
{
	public class FactoryMapper<T, N> : IFactoryMapper<T, N>
	{
		private MapperConfigUser mapperConfig;

		public FactoryMapper() => mapperConfig = new MapperConfigUser();

		public T AddDomain(N entity)
		{
			return mapperConfig.CreateMapper().Map<T>(entity);
		}

	}
}