using System;
using AutoMapper;

namespace music_store.Services.Interfaces
{
	public abstract class AMapperConfig : Profile
	{
		public static object InitializeAutomapper()
		{
			throw new NotImplementedException();
		}

		/*! 
		* @brief Buying a record, charging money from the user's balance.
		*/
		public AMapperConfig() { }

		/*! 
		* @brief Create Configuration Mapper.
		* @return IMapper - Mapper Configuration.
		*/
		public virtual IMapper CreateMapper()
		{
			return CreateMapper();
		}
	}
}
