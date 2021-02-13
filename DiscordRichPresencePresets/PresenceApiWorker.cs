﻿using System;
using DiscordRPC;

namespace DiscordRichPresencePresets
{
	public class PresenceApiWorker
	{
		private readonly DiscordRpcClient RpcClient;

		public PresenceApiWorker(string token)
		{
			RpcClient = new(token);
			RpcClient.Initialize();
			RpcClient.Invoke();
		}

		public void SetRichPresence(Presence presence)
		{
			RpcClient.SetPresence(new RichPresence
			{
				Assets = new Assets
				{
					LargeImageKey  = presence.BigImage,
					LargeImageText = presence.BigImageText,
					SmallImageKey  = presence.SmallImage,
					SmallImageText = presence.SmallImageText
				},
				Details    = presence.Data1,
				Party      = null,
				Secrets    = null,
				State      = presence.Data2,
				Timestamps = null,
				Buttons    = Array.Empty<Button>()
			});

			RpcClient.Invoke();
		}

		public void RemoveRichPresence()
		{
		}
	}
}