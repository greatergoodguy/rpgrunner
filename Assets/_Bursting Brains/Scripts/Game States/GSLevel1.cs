using UnityEngine;
using System.Collections;

public class GSLevel1 : GS_Base {

	CtrlPlayer ctrlPlayer;
	CtrlLevel1 ctrlLevel1;

	bool isFinished;
	
	public GSLevel1() {
		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
		ctrlLevel1 = FactoryOfControllers.GetCtrlLevel1();
	}
	
	public override void StartState () {
		base.StartState ();

		ctrlPlayer.SetVisible(true);
		ctrlPlayer.SetPosition(Vector3.zero);

		ctrlLevel1.SetVisible(true);

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