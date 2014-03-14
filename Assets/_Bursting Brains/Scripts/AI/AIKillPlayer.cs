using UnityEngine;
using System.Collections;

public class AIKillPlayer : MonoBehaviour {

	CtrlPlayer ctrlPlayer;
	
	void Start () {
		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
	}

	void OnTriggerEnter(Collider other) {
		UtilLogger.LogInfo("AIKillPlayer", "OnTriggerEnter()");
		ctrlPlayer.SwitchStateDead();
	}
}
