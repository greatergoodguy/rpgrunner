using UnityEngine;
using System.Collections;

public abstract class GS_Base : GS_Interface {
        
	public GS_Base() {}

    public virtual void StartState () {
		UtilLogger.LogInfo("GameState", ToString() + " Start State");
	}
	
	public virtual void Update () {
		
	}
    
	public virtual void ExitState () {
		UtilLogger.LogInfo("GameState", ToString() + " Exit State");

	}
	
    public abstract bool IsFinished();
    public abstract GS_Interface GetNextGameState() ;
}