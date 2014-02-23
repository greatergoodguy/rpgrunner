using UnityEngine;
using System.Collections;

public class PSJump : PS_Base {

	CtrlPlayer ctrlPlayer;

	public PSJump() {
		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
	}

	public override void StartState (){
		base.StartState ();
		ctrlPlayer.Jump();
	}

	public override void Update (){
		base.Update ();

		ctrlPlayer.UpdateFromRunning();
	}

	public override bool IsFinished() {
		return true;}
	
	public override PS_Interface GetNextPlayerState() {	
		return PlayerStates.psAirbourne;}
}
