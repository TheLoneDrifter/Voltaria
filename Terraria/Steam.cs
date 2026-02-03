using System;
using System.Runtime.InteropServices;
namespace Terraria
{
	public class Steam
	{
		public static bool SteamInit;
		[DllImport("steam_api.dll")]
		private static extern bool SteamAPI_Init();
		[DllImport("steam_api.dll")]
		private static extern bool SteamAPI_Shutdown();
		public static void Init()
		{
			try
			{
				Steam.SteamInit = Steam.SteamAPI_Init();
			}
			catch (DllNotFoundException)
			{
				// Steam API DLL missing — run without Steam features
				Steam.SteamInit = false;
			}
			catch (Exception)
			{
				// Any other error — disable Steam integration
				Steam.SteamInit = false;
			}
		}
		public static void Kill()
		{
			if (!Steam.SteamInit) return;
			try
			{
				Steam.SteamAPI_Shutdown();
			}
			catch
			{
				// ignore shutdown errors
			}
		}
	}
}
