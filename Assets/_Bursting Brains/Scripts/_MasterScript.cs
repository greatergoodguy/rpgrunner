using UnityEngine;
using System.Collections;

public class _MasterScript : MonoBehaviour {
	
	GS_Interface activeGameState;
	
	void Awake () {
		activeGameState = GameStates.GetInitialGameState();
	}
	
	void Start () {
		activeGameState.StartState();
	}
	
	void Update () {
		activeGameState.Update();
		
		if(activeGameState.IsFinished()) {
			activeGameState.ExitState();
			activeGameState = activeGameState.GetNextGameState();
			activeGameState.StartState();
		}
	}
}