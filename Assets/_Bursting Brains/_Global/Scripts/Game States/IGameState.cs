using UnityEngine;
using System.Collections;

public interface IGameState{
	void StartState();
	void Update();
	void ExitState();
	
	bool IsFinished();
	IGameState GetNextGameState();
}