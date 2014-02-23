using UnityEngine;
using System.Collections;

public class CtrlCamera : Ctrl_Base {

	Transform target;

	private float distance = 15.0f;
	private float extraHeight = 0.0f;

	void Update() {
		if(target) {
			Vector3 targetPos = target.position + Vector3.up * extraHeight;
			targetPos.z = targetPos.z - distance;
			transform.position -= (transform.position - targetPos) * 0.25f;
		}
	}

	public void TrackPlayer(CtrlPlayer ctrlPlayer) {
		this.target = ctrlPlayer.transform;
	}
}
