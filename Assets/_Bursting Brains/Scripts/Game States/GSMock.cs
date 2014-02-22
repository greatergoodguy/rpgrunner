using UnityEngine;
using System.Collections;

public class GSMock : GS_Base {
	
	public override bool IsFinished() {
		return false;}
	
	public override GS_Interface GetNextGameState() {	
		return GameStates.gsMock;}
}