using System;
using System.ComponentModel;
using UnityEngine;
using UnityModManagerNet;

namespace baoli_DE7
{
	public class Settings : UnityModManager.ModSettings
	{
		public enum DE6GZType
		{
			[Description("Default")]
			None,

			[Description("G26cu-Hong Kong")]
			Chinese,
		}

		public DE6GZType de6GZType = DE6GZType.Chinese;

		public void Draw(UnityModManager.ModEntry modEntry)
		{
			// GUILayout.BeginVertical();

			GUILayout.Label("G26CU改裝主體");
			GUILayout.Label("別稱G26CU製造商General Motors生產年份1974年、1977年列車數量3行駛路綫東鐵綫投入服務年份1974年、1977年退役年份2021年");

			// GUILayout.Space(2f);

			GUILayout.Label("改裝主體");
			de6GZType = (DE6GZType)GUILayout.SelectionGrid((int)de6GZType, Enum.GetNames(typeof(DE6GZType)), 1, "toggle");
			//
			// GUILayout.EndVertical();
		}

		public override void Save(UnityModManager.ModEntry modEntry)
		{
			Save(this, modEntry);
		}
	}
}
