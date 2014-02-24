using UnityEngine;
using System.Collections;

public class AIGround : MonoBehaviour {

	CtrlPlayer ctrlPlayer;
	
	void Start () {
		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
	}

	void OnTriggerEnter(Collider other) {
		UtilLogger.LogInfo("AIGround", "OnTriggerEnter()");
		ctrlPlayer.SwitchStateRunning();
	}

	void OnTriggerExit(Collider other) {
		UtilLogger.LogInfo("AIGround", "OnTriggerExit()");
		ctrlPlayer.SwitchStateAirbourne();
	}
}
