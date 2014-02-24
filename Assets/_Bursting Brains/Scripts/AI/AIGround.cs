using UnityEngine;
using System.Collections;

public class AIGround : MonoBehaviour {

	CtrlPlayer ctrlPlayer;
	
	void Start () {
		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
	}

	void OnTriggerEnter(Collider other) {
		print ("OnTriggerEnter()");
		ctrlPlayer.SwitchStateRunning();
	}

	void OnTriggerExit(Collider other) {
		print ("OnTriggerExit()");
		ctrlPlayer.SwitchStateAirbourne();
	}

	void OnCollisionEnter(Collision collision) {
		print ("OnCollisionEnter()");
	}
}
