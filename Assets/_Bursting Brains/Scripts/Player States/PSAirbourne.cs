using UnityEngine;
using System.Collections;

public class PSAirbourne : PS_Base {

	CtrlPlayer ctrlPlayer;

	bool isFinished;

	public PSAirbourne() {
		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
	}

	public override void StartState () {
		base.StartState ();

		isFinished = false;
	}
	public override void Update () {
		base.Update ();

		ctrlPlayer.UpdateFromRunning();
		ctrlPlayer.UpdateFromGravity();

		if(ctrlPlayer.IsOnGround()){
			isFinished = true;
		}
	}

	public override bool IsFinished() {
		return isFinished;}
	
	public override PS_Interface GetNextPlayerState() {	
		return PlayerStates.psRunning;}
}
