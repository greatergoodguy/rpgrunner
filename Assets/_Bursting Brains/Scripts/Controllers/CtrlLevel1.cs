using UnityEngine;
using System.Collections;

public class CtrlLevel1 : Ctrl_Base {
	
	void Start () {
		SetVisible(false);
	}

	public Vector3 GetStartPosition() {
		Transform tStartPosition = transform.FindChild_BB("Start Position");
		return tStartPosition.position;
	}
}
