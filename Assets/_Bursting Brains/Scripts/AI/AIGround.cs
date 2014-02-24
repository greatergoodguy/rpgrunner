using UnityEngine;
using System.Collections;

public class AIGround : MonoBehaviour {

	CtrlPlayer ctrlPlayer;
	
	void Start () {
		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag != "Player") {
			return;}

		UtilLogger.LogInfo("AIGround", "OnTriggerEnter()");
		ctrlPlayer.SwitchStateRunning();
	}

	void OnTriggerExit(Collider other) {
		if(other.tag != "Player") {
			return;}

		UtilLogger.LogInfo("AIGround", "OnTriggerExit()");
		ctrlPlayer.SwitchStateAirbourne();
	}
}
