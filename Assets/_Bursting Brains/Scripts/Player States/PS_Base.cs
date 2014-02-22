using UnityEngine;
using System.Collections;

public abstract class PS_Base : PS_Interface {

	public PS_Base() {}
	
	public virtual void StartState () {
		UtilLogger.LogInfo("PlayerState", ToString() + " Start State");
	}
	
	public virtual void Update () {
		
	}
	
	public virtual void ExitState () {
		UtilLogger.LogInfo("PlayerState", ToString() + " Exit State");
	}
	
	public abstract bool IsFinished();
	public abstract PS_Interface GetNextPlayerState() ;
}
