using UnityEngine;
using System.Collections;

public abstract class GameStateBase : IGameState {
        
	public GameStateBase() {}
    public virtual void StartState () {
		Debug.Log(ToString() + ": Start State");
	}
	
	public virtual void Update () {
		
	}
    
	public virtual void ExitState () {
		Debug.Log(ToString() + ": Exit State");
	}
	
    public abstract bool IsFinished();
    public abstract IGameState GetNextGameState() ;
}