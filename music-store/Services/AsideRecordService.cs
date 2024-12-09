using System;
using System.Linq;
using music_store.Models.Domains;
using music_store.Models.Entities;
using music_store.Services.Interfaces;

namespace music_store.Services
{
	public class AsideRecordService : IAsideRecordService
	{
		private readonly ADatabaseConnection _db;
		private readonly IFactoryMapper _mapper;

		public AsideRecordService(ADatabaseConnection context, IFactoryMapper mapper)
		{
			_db = context;
			_mapper = mapper;
		}

		public void AddAsideRecord(string vinylRecordName, User user)
		{
			var vinylRecord = _db.VinylRecords.FirstOrDefault(v => v.Name == vinylRecordName);
			if (vinylRecord == null)
			{
				throw new Exception("Пластинка не найдена.");
			}

			DTOAsideRecord dtoAsideRecord = new DTOAsideRecord
			{
				VinylRecord = vinylRecord,
				User = user
			};

			var mapper = _mapper.GetMapperConfig().CreateMapper();

			AsideRecord asideRecord = mapper.Map<AsideRecord>(dtoAsideRecord);

			_db.AsideRecord.Add(asideRecord);
			_db.SaveChanges();
		}
	}
}