using UnityEngine;
using System.Collections;

public class OnBoundsExit : MonoBehaviour {
	
	Character_Base character;
	
	void Awake() {
		character = transform.parent.GetComponent<Character_Base>();
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag != "Player") {
			return;}
		
		UtilLogger.LogInfo("OnBoundsExit", "OnTriggerEnter()");
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag != "Player") {
			return;}
		
		UtilLogger.LogInfo("OnBoundsExit", "OnTriggerExit()");
		character.OnBoundsExit();
	}
}
