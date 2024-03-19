using System;
using System.IO;
using System.Reflection;
using HarmonyLib;
using UnityModManagerNet;
using UnityEngine;

namespace baoli_DE7
{
	[EnableReloading]
	public static class Main
	{
		private static UnityModManager.ModEntry MyModEntry;
		public static Settings MySettings { get; private set; }

		public static GameObject g26cu_hPrefab;

		private static bool Load(UnityModManager.ModEntry modEntry)
		{
			Harmony harmony = null;

			try                                                                                                                                                                                   
			{
				MyModEntry = modEntry;
				MySettings = UnityModManager.ModSettings.Load<Settings>(MyModEntry);

				MyModEntry.OnGUI = entry => MySettings.Draw(entry);
				MyModEntry.OnSaveGUI = entry => MySettings.Save(entry);

				string assetPath = Path.Combine(MyModEntry.Path, "assetbundles\\");

				g26cu_hPrefab = AssetBundle.LoadFromFile(Path.Combine(assetPath, "CRDE6"))
					.LoadAsset<GameObject>("Assets/Prefab/g26cu_hk.prefab");
			 
				harmony = new Harmony(MyModEntry.Info.Id);
				harmony.PatchAll(Assembly.GetExecutingAssembly());
			}
			catch (Exception ex)
			{
				MyModEntry.Logger.LogException($"Failed to load {MyModEntry.Info.DisplayName}:", ex);
				harmony?.UnpatchAll(MyModEntry.Info.Id);
				return false;
			}

			return true;
		}

		// Logger Commands
		public static void Log(string message)
		{
			MyModEntry.Logger.Log(message);
		}

		public static void Warning(string message)
		{
			MyModEntry.Logger.Warning(message);
		}

		public static void Error(string message)
		{
			MyModEntry.Logger.Error(message);
		}
	}
}
