using UnityEngine;
using System.Collections;

public static class FactoryOfControllers {

	static CtrlMenuStart ctrlMenuStart;
	public static CtrlMenuStart GetCtrlMenuStart() {
		if(ctrlMenuStart == null)
			ctrlMenuStart = GameObject.Find("Menu Start").GetComponent_BB<CtrlMenuStart>();
		
		return ctrlMenuStart;
	}
}
