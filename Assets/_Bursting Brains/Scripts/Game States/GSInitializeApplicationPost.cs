using UnityEngine;
using System.Collections;

public class GSInitializeApplicationPost : GS_Base {

	CtrlPlayer ctrlPlayer;
	CtrlHealth ctrlHealth;

	public override void StartState () {
		base.StartState ();

		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
		ctrlHealth = FactoryOfControllers.GetCtrlHealth();

		ctrlPlayer.addObserver(ctrlHealth);
		ctrlHealth.TrackPlayer(ctrlPlayer);
	}

	public override bool IsFinished() {
		return true;
	}
	
	public override GS_Interface GetNextGameState() {
		return GameStates.gsMenuStart;
	}
}