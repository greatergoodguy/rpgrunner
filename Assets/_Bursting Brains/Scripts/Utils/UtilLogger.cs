using UnityEngine;
using System.Collections;

public static class UtilLogger {

	public static void LogInfo(string tag, string message) {
		if(!(tag == "OnTriggerEnterPlayer" || tag == "OnTriggerEnterCharacter")) {
			return;}

		Debug.Log(tag + ": " + message);
	}
}
