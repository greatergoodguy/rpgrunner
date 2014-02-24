using UnityEngine;
using System.Collections;

public class AIShortLife : MonoBehaviour {

	private static float LIFE_DURATION_IN_MILLISECONDS = 5;

	float timer;
	
	void Awake () {

	}

	void Update() {
		timer += Time.deltaTime;

		if(timer > LIFE_DURATION_IN_MILLISECONDS) {
			Destroy(gameObject);
		}
	}

}
