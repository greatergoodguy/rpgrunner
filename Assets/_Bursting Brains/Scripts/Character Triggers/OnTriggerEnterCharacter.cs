using UnityEngine;
using System.Collections;

public class OnTriggerEnterCharacter : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		if(other.tag != "Player") {
			return;}
		
		UtilLogger.LogInfo("OnTriggerEnterCharacter", "OnTriggerEnter()");
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag != "Player") {
			return;}
		
		UtilLogger.LogInfo("OnTriggerEnterCharacter", "OnTriggerExit()");
	}
}
