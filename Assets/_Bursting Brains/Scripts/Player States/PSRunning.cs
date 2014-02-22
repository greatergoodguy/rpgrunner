using UnityEngine;
using System.Collections;

public class PSRunning : PS_Base {

	CtrlPlayer ctrlPlayer;

	public PSRunning() {
		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
	}

	public override void Update () {
		base.Update ();

		if(!ctrlPlayer.IsOnGround()){
			ctrlPlayer.UpdateFromGravity();
		}
	}

	public override bool IsFinished() {
		return false;}
	
	public override PS_Interface GetNextPlayerState() {	
		return PlayerStates.psMock;}
}
