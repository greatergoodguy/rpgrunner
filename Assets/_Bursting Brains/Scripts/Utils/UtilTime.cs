using UnityEngine;
using System.Collections;

public static class UtilTime {

	public static void SetTimeScaleToZero() {
		Time.timeScale = 0;
	}

	public static void SetTimeScaleToOne() {
		Time.timeScale = 1;
	}

	public static bool IsTimeScaleZero() {
		if(Time.timeScale == 0) {
			return true;}
		else {
			return false;}
	}
}
