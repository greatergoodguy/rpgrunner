using UnityEngine;
using System.Collections;

public class GSInitializeApplicationPost : GS_Base {

	CtrlViewport ctrlViewport;
	CtrlPlayer ctrlPlayer;
	CtrlHealth ctrlHealth;
	CtrlBank ctrlBank;

	public GSInitializeApplicationPost() {
		ctrlViewport = FactoryOfControllers.GetCtrlViewport();
		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
		ctrlHealth = FactoryOfControllers.GetCtrlHealth();
		ctrlBank = FactoryOfControllers.GetCtrlBank();
	}

	public override void StartState () {
		base.StartState ();

		ctrlPlayer.addObserver(ctrlHealth);
		ctrlHealth.TrackPlayer(ctrlPlayer);
		ctrlBank.TrackPlayer(ctrlPlayer);

	}

	public override bool IsFinished() {
		return true;
	}
	
	public override GS_Interface GetNextGameState() {
		return GameStates.gsMenuStart;
	}
}