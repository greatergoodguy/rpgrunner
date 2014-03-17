using UnityEngine;
using System.Collections;

public class OnBoundsEnter : MonoBehaviour {

	Character_Base character;

	void Awake() {
		character = transform.parent.GetComponent<Character_Base>();
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag != "Player") {
			return;}
		
		UtilLogger.LogInfo("OnBoundsEnter", "OnTriggerEnter()");
		character.OnBoundsEnter();
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag != "Player") {
			return;}
		
		UtilLogger.LogInfo("OnBoundsEnter", "OnTriggerExit()");
	}
}
