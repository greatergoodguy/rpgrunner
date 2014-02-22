using UnityEngine;
using System.Collections;

public class CtrlMusic : Ctrl_Base {
	
	protected static string TAG = "CtrlMusic";
	
	AudioSource asOncomingLights;
	
	void Awake() {
		Transform tMusicBox = transform.FindChild_BB("Music Box");
		
		asOncomingLights = tMusicBox.FindChild_BB("Oncoming Lights").GetComponent<AudioSource>();
	}

	// =============================
	// Oncoming Lights
	// =============================
	public void PlayOncomingLights() {	asOncomingLights.Play();}
	public void PauseOncomingLights() {	asOncomingLights.Pause();}
	public void StopOncomingLights() {	asOncomingLights.Stop();}
}
