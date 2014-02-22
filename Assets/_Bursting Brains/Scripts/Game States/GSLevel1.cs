using UnityEngine;
using System.Collections;

public class GSLevel1 : GS_Base {

	CtrlPlayer ctrlPlayer;
	CtrlLevel1 ctrlLevel1;
	CtrlMusic ctrlMusic;
	CtrlSfx ctrlSfx;

	bool isFinished;
	
	public GSLevel1() {
		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
		ctrlLevel1 = FactoryOfControllers.GetCtrlLevel1();
		ctrlMusic = FactoryOfControllers.GetCtrlMusic();
		ctrlSfx = FactoryOfControllers.GetCtrlSfx();
	}
	
	public override void StartState () {
		base.StartState ();

		Vector3 startPosition = ctrlLevel1.GetStartPosition();

		ctrlPlayer.SetVisible(true);
		ctrlPlayer.SetPosition(startPosition);

		ctrlPlayer.SetDelOnJump(ctrlSfx.PlayJump);
		ctrlPlayer.SetDelOnAttack(ctrlSfx.PlayAttack);

		ctrlLevel1.SetVisible(true);

		ctrlMusic.PlayOncomingLights();

		isFinished = false;
	}
	
	public override void ExitState () {
		base.ExitState ();
	}
	
	public override bool IsFinished() {
		return isFinished;
	}
	
	public override GS_Interface GetNextGameState() {
		return GameStates.gsMock;
	}
}