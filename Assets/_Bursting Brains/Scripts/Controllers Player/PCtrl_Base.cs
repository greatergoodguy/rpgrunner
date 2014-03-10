using UnityEngine;
using System.Collections;

public abstract class PCtrl_Base : MonoBehaviour {
	
	public abstract void Shoot();

	public void SetActiveTrue() {
		gameObject.SetActive(true);
	}

	public void SetActiveFalse() {
		gameObject.SetActive(false);
	}
}
