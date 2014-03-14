using UnityEngine;
using System.Collections;

public class GSInitializeApplicationPost : GS_Base {

	CtrlPlayer ctrlPlayer;
	CtrlHealth ctrlHealth;
	CtrlBank ctrlBank;

	public GSInitializeApplicationPost() {
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