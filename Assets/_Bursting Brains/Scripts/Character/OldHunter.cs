using UnityEngine;
using System.Collections;

public class OldHunter : Character_Base {

	GameObject goVisual;

	void Awake() {
		goVisual = transform.FindChild_BB("Visual").gameObject;
	}

	protected override void OnTriggerEnterCharacter() {

	}
}
