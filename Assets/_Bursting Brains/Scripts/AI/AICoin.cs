using UnityEngine;
using System.Collections;

public class AICoin : MonoBehaviour {

	CtrlBank ctrlBank;

	void Start() {
		ctrlBank = FactoryOfControllers.GetCtrlBank();
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag != "Player") {
			return;}

		ctrlBank.IncreaseBankBy5();
		Destroy(gameObject);
	}
}
