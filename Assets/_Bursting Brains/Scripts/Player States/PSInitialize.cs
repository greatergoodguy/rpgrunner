using UnityEngine;
using System.Collections;

public class PSInitialize : PS_Base {

	public override bool IsFinished() {
		return true;}
	
	public override PS_Interface GetNextPlayerState() {	
		return PlayerStates.psRunning;}
}
