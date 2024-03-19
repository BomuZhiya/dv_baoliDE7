using DV.ThingTypes;
using HarmonyLib;
using UnityEngine;
using static baoli_DE7.Main;

namespace baoli_DE7
{
	[HarmonyPatch(typeof(TrainCar), "Start")]
class CarPatch {
	static void Postfix(ref TrainCar __instance)
	{
		if (__instance == null || __instance.carType != TrainCarType.LocoDiesel)
		{
			return;
		}

		string De6bodyPath = "LocoDE6_Body/Body";
		Transform De6Body = __instance.transform.Find(De6bodyPath);
		if (De6Body == null)
		{
			Error($"Couldn't find DE6 body on '{__instance.transform.gameObject.name}' -> {De6bodyPath}");
			return;
		}

		// Smoke Deflector
		Log($"Applying {MySettings.de6GZType.ToString()}");

		switch (MySettings.de6GZType) {
			case Settings.DE6GZType.Chinese:
				ApplyChineseDE6(ref __instance, De6Body);
				break;
		}
	}

	private static void ApplyChineseDE6(ref TrainCar locomotive, Transform body)
	{
		//hide  
		var ChineseDE6Path = "LocoDE6_Body/Body/diesel_body_LOD0";
		Transform ChineseADE6 = locomotive.transform.Find(ChineseDE6Path);
		ChineseADE6.gameObject.SetActive(false);

		var FlightglassPath = "[headlights]/FrontSide/headlight_glass";
		Transform Flightglass = locomotive.transform.Find(FlightglassPath);
		Flightglass.gameObject.GetComponent<MeshRenderer>().enabled = false;

		var FlightglassredmrPath = "[headlights]/FrontSide/headlight_glass_red";
		Transform Flightglassredmr = locomotive.transform.Find(FlightglassredmrPath);
		Flightglassredmr.gameObject.GetComponent<MeshRenderer>().enabled = false;

		var RlightglassPath = "[headlights]/RearSide/headlight_glass";
		Transform Rlightglass = locomotive.transform.Find(RlightglassPath);
		Rlightglass.gameObject.GetComponent<MeshRenderer>().enabled = false;

		var RlightglassredmrPath = "[headlights]/RearSide/headlight_glass_red";
		Transform Rlightglassredmr = locomotive.transform.Find(RlightglassredmrPath);
		Rlightglassredmr.gameObject.GetComponent<MeshRenderer>().enabled = false;

		var tophaiPath = "[headlights]/FrontSide/HeadlightTopHigh";
		Transform tophai = locomotive.transform.Find(tophaiPath);
		tophai.gameObject.SetActive(false);

		var toplouPath = "[headlights]/FrontSide/HeadlightTopLow";
		Transform toplou = locomotive.transform.Find(toplouPath);
		toplou.gameObject.SetActive(false);

		var redfPath = "[headlights]/FrontSide/HeadlightBottom";
		Transform redf = locomotive.transform.Find(redfPath);
		redf.gameObject.SetActive(false);

		var tophairPath = "[headlights]/RearSide/HeadlightTopHigh";
		Transform Rlightglassred = locomotive.transform.Find(tophairPath);
		Rlightglassred.gameObject.SetActive(false);

		var tophairlPath = "[headlights]/RearSide/HeadlightTopLow";
		Transform RHeadlightTopLow = locomotive.transform.Find(tophairlPath);
		RHeadlightTopLow.gameObject.SetActive(false);

		var RHeadlightBottomPath = "[headlights]/RearSide/HeadlightBottom";
		Transform RHeadlightBottom = locomotive.transform.Find(RHeadlightBottomPath);
		RHeadlightBottom.gameObject.SetActive(false);

		var body2Path = "LocoDE6_Body/Body/diesel_body_LOD1";
		Transform body2 = locomotive.transform.Find(body2Path);
		body2.gameObject.SetActive(false);

		var body3Path = "LocoDE6_Body/Body/diesel_body_LOD2";
		Transform body3 = locomotive.transform.Find(body3Path);
		body3.gameObject.SetActive(false);

		var body4Path = "LocoDE6_Body/Body/diesel_body_LOD3";
		Transform body4 = locomotive.transform.Find(body4Path);
		body4.gameObject.SetActive(false);

		var body5Path = "LocoDE6_Body/Body/diesel_body_LOD4";
		Transform body5 = locomotive.transform.Find(body5Path);
		body5.gameObject.SetActive(false);

		var anchor1Path = "[car plate anchor1]";
		Transform anchor1 = locomotive.transform.Find(anchor1Path);
		anchor1.gameObject.SetActive(false);

		var anchor2Path = "[car plate anchor2]";
		Transform anchor2 = locomotive.transform.Find(anchor2Path);
		anchor2.gameObject.SetActive(false);

		//var cablod1Path = "[interior LOD]/LocoDE6_InteriorLOD/cab_LOD1";
		//Transform cablod1 = locomotive.transform.Find(cablod1Path);
		//cablod1.gameObject.SetActive(false);

		//var cablod2Path = "[interior LOD]/LocoDE6_InteriorLOD/cab_LOD2";
		//Transform cablod2 = locomotive.transform.Find(cablod2Path);
		//cablod2.gameObject.SetActive(false);

		var leftlowlightPath = "[headlights]/FrontSide/HeadlightLeftLow";
		Transform leftlowlight = locomotive.transform.Find(leftlowlightPath);
		leftlowlight.transform.localPosition = new Vector3(0.62f, 1.6f, -1.22f);

		var lefthailightPath = "[headlights]/FrontSide/HeadlightLeftHigh";
		Transform lefthailight = locomotive.transform.Find(lefthailightPath);
		lefthailight.transform.localPosition = new Vector3(0.62f, 1.6f, -1.22f);

		var rightlowlightPath = "[headlights]/FrontSide/HeadlightRightLow";
		Transform rightlowlight = locomotive.transform.Find(rightlowlightPath);
		rightlowlight.transform.localPosition = new Vector3(-0.62f, 1.79f, -1.22f);

		var righthailightPath = "[headlights]/FrontSide/HeadlightRightHigh";
		Transform righthailight = locomotive.transform.Find(righthailightPath);
		righthailight.transform.localPosition = new Vector3(-0.62f, 1.79f, -1.22f);

			//var CabmPath = "Cab";
			//Transform Cabm = locomotive.transform.Find(CabmPath);
			//Transform Cabmtransform2 = locomotive.transform;
			//Debug.Log("位置" + Cabmtransform2.position + "旋转" + Cabmtransform2.rotation + "缩放" + Cabmtransform2.localScale);
			//Cabm.transform.localPosition = new Vector3(999.0f, 0.0f, 0.0f);

			//var CabmPath = "LocoDE6(Clone) [interior]/LocoDE6_Interior(Clone)/Cab";
			//Transform Cabm = locomotive.transform.Find(CabmPath);
			//Cabm.gameObject.GetComponent<MeshRenderer>().enabled = false;

		var rleftlowlightPath = "[headlights]/RearSide/HeadlightLeftLow";
		Transform rleftlowlight = locomotive.transform.Find(rleftlowlightPath);
		rleftlowlight.transform.localPosition = new Vector3(-0.621f, 1.74f, -0.15f);

		var rlefthailightPath = "[headlights]/RearSide/HeadlightLeftHigh";
		Transform rlefthailight = locomotive.transform.Find(rlefthailightPath);
		rlefthailight.transform.localPosition = new Vector3(-0.621f, 1.74f, -0.15f);

		var rrightlowlightPath = "[headlights]/RearSide/HeadlightRightLow";
		Transform rrightlowlight = locomotive.transform.Find(rrightlowlightPath);
		rrightlowlight.transform.localPosition = new Vector3(0.621f, 1.56f, -0.13f);

		var rrighthailightPath = "[headlights]/RearSide/HeadlightRightHigh";
		Transform rrighthailight = locomotive.transform.Find(rrighthailightPath);
		rrighthailight.transform.localPosition = new Vector3(0.621f, 1.56f, -0.13f);


			//show deflector and stuff
			GameObject chineseDE6 = Object.Instantiate(g26cu_hPrefab, body);
		chineseDE6.transform.localPosition = ChineseADE6.localPosition;
	}
	}

}
