using UnityEngine;
using System.Collections;

public class _MasterScript : MonoBehaviour {
	
	IGameState activeGameState;
	
	void Awake () {
		activeGameState = GameFlow.GetInitialGameState();
		
		// We make calls to all the Factory methods to ensure that
		// each Controller works as expected. If an error is thrown,
		// it's best to catch that early, as in the very beginning of
		// program. This strategy is lazy initialization and should be 
		// suitable as long as the game is light weight.
		
		//FactoryOfControllers.ExecuteAllGetMethods();
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