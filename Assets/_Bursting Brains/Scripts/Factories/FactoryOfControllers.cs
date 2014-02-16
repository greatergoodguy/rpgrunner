using UnityEngine;
using System.Collections;

public static class FactoryOfControllers {

	static CtrlMenuStart ctrlMenuStart;
	public static CtrlMenuStart GetCtrlMenuStart() {
		if(ctrlMenuStart == null)
			ctrlMenuStart = GameObject.Find("Menu Start").GetComponent_BB<CtrlMenuStart>();
		
		return ctrlMenuStart;
	}


	static CtrlPlayer ctrlPlayer;
	public static CtrlPlayer GetCtrlPlayer() {
		if(ctrlPlayer == null)
			ctrlPlayer = GameObject.Find("Player").GetComponent_BB<CtrlPlayer>();
		
		return ctrlPlayer;
	}
}
