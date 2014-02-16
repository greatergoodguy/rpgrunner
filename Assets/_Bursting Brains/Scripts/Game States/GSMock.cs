using UnityEngine;
using System.Collections;

public class GSMock : GS_Base {
	
	public override bool IsFinished() {
		return false;
	}
	
	public override IGameState GetNextGameState() {
		return GameFlow.gsMock;
	}
}