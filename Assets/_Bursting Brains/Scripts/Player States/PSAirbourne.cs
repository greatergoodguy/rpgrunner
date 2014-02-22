using UnityEngine;
using System.Collections;

public class PSAirbourne : PS_Base {

	public override bool IsFinished() {
		return false;}
	
	public override PS_Interface GetNextPlayerState() {	
		return PlayerStates.psMock;}
}
