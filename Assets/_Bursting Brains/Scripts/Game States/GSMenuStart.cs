using UnityEngine;
using System.Collections;

public class GSMenuStart : GS_Base {
	
	bool isFinished;
	
	public GSMenuStart() {
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
		return null;
	}
	
	void Finish() {
		isFinished = true;
	}
}