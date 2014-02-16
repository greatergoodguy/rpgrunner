using UnityEngine;
using System.Collections;

public class CtrlMenuStart : Ctrl_Base {

	DelButton delPlay = UtilMock.MockFunction;
	DelButton delQuit = UtilMock.MockFunction;

	void Start() {
		SetVisible(false);
	}

	public void ButtonPlay() {
		delPlay();}

	public void SetDelPlay(DelButton delPlay) {
		this.delPlay = delPlay;}

	public void ButtonQuit() {
		Application.Quit();}

	public void SetVisible(bool isVisible) {
		if(isVisible) 	gameObject.SetActive(true);
		else 			gameObject.SetActive(false);
	}
	
	public bool IsVisible() {
		return gameObject.activeSelf;
	}
}
