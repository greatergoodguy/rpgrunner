using UnityEngine;
using System.Collections;

public abstract class Ctrl_Base : MonoBehaviour{
		
	public void SetVisible(bool isVisible) {
		if(isVisible) 	gameObject.SetActive(true);
		else 			gameObject.SetActive(false);
	}
	
	public bool IsVisible() {
		return gameObject.activeSelf;
	}
	
	public void SetPositionToOrigin() {
		transform.position = Vector3.zero;
	}
}
