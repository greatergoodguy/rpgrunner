using UnityEngine;
using System.Collections;

public class CtrlMenuPause : Ctrl_Base {

	DelButton delResume = UtilMock.MockFunction;
	DelButton delQuit = UtilMock.MockFunction;

	void Start() {
		SetVisible(false);
	}
	
	public void SetDelResume(DelButton delResume) {
		this.delResume = delResume;}
	
	public void ButtonResume() {
		delResume();}
	
	public void SetDelQuit(DelButton delQuit) {
		this.delQuit = delQuit;}
	
	public void ButtonQuit() {
		delQuit();}
}
