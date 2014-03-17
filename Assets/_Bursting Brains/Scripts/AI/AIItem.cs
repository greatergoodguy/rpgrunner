using UnityEngine;
using System.Collections;

public class AIItem : MonoBehaviour {

	//CtrlPlayer ctrlPlayer;

	// Use this for initialization
	void Start () {
		//ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag != "Player") {
			return;}

		UtilLogger.LogInfo("AIItem", "OnTriggerEnter()");
		Destroy(gameObject);
	}
}
