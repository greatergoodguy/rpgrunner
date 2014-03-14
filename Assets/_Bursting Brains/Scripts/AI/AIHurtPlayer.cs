using UnityEngine;
using System.Collections;

public class AIHurtPlayer : AI_Base {
	CtrlPlayer ctrlPlayer;
	
	void Start () {
		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
	}
	
	void OnTriggerEnter(Collider other) {
		UtilLogger.LogInfo("AIHurtPlayer", "OnTriggerEnter()");
		ctrlPlayer.ReceiveOneDamage();
	}
}
