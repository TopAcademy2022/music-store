﻿using music_store.Models.Entities;

namespace music_store.Models.Domains
{
	public class DomainUser
	{
		public string Login { get; set; } = null!;

		public Wallet Wallet { get; set; } = null!;

	}
}