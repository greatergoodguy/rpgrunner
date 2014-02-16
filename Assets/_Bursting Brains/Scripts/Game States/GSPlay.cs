using UnityEngine;
using System.Collections;

public class GSPlay : GS_Base {

	CtrlPlayer ctrlPlayer;

	bool isFinished;
	
	public GSPlay() {
		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
	}
	
	public override void StartState () {
		base.StartState ();

		ctrlPlayer.SetVisible(true);

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