using UnityEngine;
using System.Collections;

public class OnTriggerEnterPlayer : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		if(other.tag != "Player") {
			return;}
		
		UtilLogger.LogInfo("OnTriggerEnterPlayer", "OnTriggerEnter()");
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag != "Player") {
			return;}
		
		UtilLogger.LogInfo("OnTriggerEnterPlayer", "OnTriggerExit()");
	}
}
