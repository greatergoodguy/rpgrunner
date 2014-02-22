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

	static CtrlLevel1 ctrlLevel1;
	public static CtrlLevel1 GetCtrlLevel1() {
		if(ctrlLevel1 == null)
			ctrlLevel1 = GameObject.Find("Level 1").GetComponent_BB<CtrlLevel1>();
		
		return ctrlLevel1;
	}

	static CtrlMusic ctrlMusic;
	public static CtrlMusic GetCtrlMusic() {
		if(ctrlMusic == null)
			ctrlMusic = GameObject.Find("Music").GetComponent_BB<CtrlMusic>();
		
		return ctrlMusic;
	}

	static CtrlSfx ctrlSfx;
	public static CtrlSfx GetCtrlSfx() {
		if(ctrlSfx == null)
			ctrlSfx = GameObject.Find("Sfx").GetComponent_BB<CtrlSfx>();
		
		return ctrlSfx;
	}
}
