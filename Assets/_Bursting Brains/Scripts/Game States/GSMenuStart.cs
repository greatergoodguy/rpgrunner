using UnityEngine;
using System.Collections;

public class GSMenuStart : GS_Base {

	CtrlMenuStart ctrlMenuStart;

	bool isFinished;
	
	public GSMenuStart() {
		ctrlMenuStart = FactoryOfControllers.GetCtrlMenuStart();
	}
	
	public override void StartState () {
		base.StartState ();

		ctrlMenuStart.SetVisible(true);
		ctrlMenuStart.SetDelPlay(Finish);

		isFinished = false;
	}
	
	public override void ExitState () {
		base.ExitState ();

		ctrlMenuStart.SetVisible(false);
	}
	
	public override bool IsFinished() {
		return isFinished;
	}
	
	public override GS_Interface GetNextGameState() {
		return GameStates.gsLevel1;
	}
	
	void Finish() {
		isFinished = true;
	}
}