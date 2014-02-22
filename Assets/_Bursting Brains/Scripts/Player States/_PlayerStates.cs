using UnityEngine;
using System.Collections;

public class PlayerStates {

	public static readonly PS_Interface psInitialize 	= new PSInitialize();
	public static readonly PS_Interface psRunning 		= new PSRunning();
	public static readonly PS_Interface psAirbourne 	= new PSAirbourne();

	public static readonly PS_Interface psMock 			= new PSMock();

	public static PS_Interface GetInitialPlayerState() {
		return psInitialize;
	}    
}
