using UnityEngine;
using System.Collections;

public class PSRunning : PS_Base {

	public override bool IsFinished() {
		return false;}
	
	public override PS_Interface GetNextPlayerState() {	
		return PlayerStates.psMock;}
}
