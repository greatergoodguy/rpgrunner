using UnityEngine;
using System.Collections;

public class CtrlSfx : Ctrl_Base {

	protected static string TAG = "CtrlSfx";

	AudioSource asJump;
	AudioSource asAttack;

	void Awake() {
		Transform tMusicBox = transform.FindChild_BB("Sfx Box");

		asJump = tMusicBox.FindChild_BB("Jump").GetComponent<AudioSource>();
		asAttack = tMusicBox.FindChild_BB("Attack").GetComponent<AudioSource>();
	}

	public void PlayJump() {	asJump.Play();}
	public void PlayAttack() {	asAttack.Play();}
	
}
