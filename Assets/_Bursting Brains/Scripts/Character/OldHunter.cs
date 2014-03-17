using UnityEngine;
using System.Collections;

public class OldHunter : Character_Base {

	GameObject goVisual;

	void Awake() {
		goVisual = transform.FindChild_BB("Visual").gameObject;
	}

	public override void OnBoundsEnter() {
		goVisual.AddComponent<ChAIRunForDuration>();
	}

	public override void OnBoundsExit() {
		ChAI_Base characterAI = goVisual.GetComponent<ChAIRunForDuration>();
		Destroy(characterAI);

	}
}
