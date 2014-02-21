using UnityEngine;
using System.Collections;

public class CtrlPlayer : Ctrl_Base {
	
	void Start () {
		SetVisible(false);
	}

	public void SetPosition(Vector3 position) {
		transform.position = position;
	}
}
