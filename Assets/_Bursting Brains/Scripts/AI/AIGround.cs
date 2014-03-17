using UnityEngine;
using System.Collections;

public class AIGround : AI_Base {

	CtrlPlayer ctrlPlayer;

	bool shouldEnterTrigger;

	void Start () {
		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag != "Player") {
			return;}

		UtilLogger.LogInfo("AIGround", "OnTriggerEnter()");

		bool isPlayerFalling = ctrlPlayer.IsFalling();

		float playerBottom = ctrlPlayer.GetBottom();
		float groundTop = getTop();
		bool isPlayerAboveGround = groundTop - playerBottom < 0.007f;

		shouldEnterTrigger = isPlayerFalling && isPlayerAboveGround;

		if(shouldEnterTrigger) {
			ctrlPlayer.OnTriggerEnterGround();}
	}

	void OnTriggerExit(Collider other) {
		if(other.tag != "Player") {
			return;}

		UtilLogger.LogInfo("AIGround", "OnTriggerExit()");

		if(shouldEnterTrigger) {
			ctrlPlayer.OnTriggerExitGround();}
	}

	private float getTop() {
		float result = collider.bounds.center.y + (collider.bounds.size.y / 2);
		return result;
	}
}
