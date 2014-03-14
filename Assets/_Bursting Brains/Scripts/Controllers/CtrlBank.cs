using UnityEngine;
using System.Collections;

public class CtrlBank : Ctrl_Base {

	Vector3 targetPositionOffset = new Vector3(0.2f, 0.2f, 0);
	Transform target;

	void Update() {
		if(target) {
			transform.position = target.position + targetPositionOffset;
		}
	}
	
	public void TrackPlayer(CtrlPlayer ctrlPlayer) {
		this.target = ctrlPlayer.transform;
	}

	public void IncreaseBankBy5() {
		UtilLogger.LogInfo("CtrlBank", "IncreaseBankBy5()");
	}
}
