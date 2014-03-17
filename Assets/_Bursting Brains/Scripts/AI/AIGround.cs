using UnityEngine;
using System.Collections;

public class AIGround : MonoBehaviour {

	CtrlPlayer ctrlPlayer;
	bool isPlayerFalling;
	
	void Start () {
		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag != "Player") {
			return;}

		UtilLogger.LogInfo("AIGround", "OnTriggerEnter()");

		isPlayerFalling = ctrlPlayer.IsFalling();
		if(isPlayerFalling) {
			ctrlPlayer.OnTriggerEnterGround();}
	}

	void OnTriggerExit(Collider other) {
		if(other.tag != "Player") {
			return;}

		UtilLogger.LogInfo("AIGround", "OnTriggerExit()");

		if(isPlayerFalling) {
			ctrlPlayer.OnTriggerExitGround();}
	}
}
