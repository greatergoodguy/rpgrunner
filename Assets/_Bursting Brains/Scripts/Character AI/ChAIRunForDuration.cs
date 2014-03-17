using UnityEngine;
using System.Collections;

public class ChAIRunForDuration : ChAI_Base {

	public float runningVelocity = 0.3f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = runningVelocity * Time.deltaTime;
		transform.Translate(deltaX, 0, 0);
	}
}
