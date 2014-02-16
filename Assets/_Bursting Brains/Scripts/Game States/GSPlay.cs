using UnityEngine;
using System.Collections;

public class GSPlay : GS_Base {

	bool isFinished;
	
	public GSPlay() {
	}
	
	public override void StartState () {
		base.StartState ();
		isFinished = false;
	}
	
	public override void ExitState () {
		base.ExitState ();
	}
	
	public override bool IsFinished() {
		return isFinished;
	}
	
	public override IGameState GetNextGameState() {
		return GameFlow.gsMock;
	}
}