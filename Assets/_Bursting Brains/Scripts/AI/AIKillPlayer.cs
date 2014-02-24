using UnityEngine;
using System.Collections;

public class AIKillPlayer : MonoBehaviour {

	CtrlPlayer ctrlPlayer;

	// Use this for initialization
	void Start () {
		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
	}

	void OnTriggerEnter(Collider other) {
		print ("OnTriggerEnter()");
		ctrlPlayer.SwitchStateDead();
	}
}
