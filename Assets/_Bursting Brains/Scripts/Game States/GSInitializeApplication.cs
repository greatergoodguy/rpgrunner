using UnityEngine;
using System.Collections;

public class GSInitializeApplication : GS_Base {
	
	public override bool IsFinished() {
		return true;
	}
	
	public override IGameState GetNextGameState() {
		return GameFlow.gsMenuStart;
	}
}