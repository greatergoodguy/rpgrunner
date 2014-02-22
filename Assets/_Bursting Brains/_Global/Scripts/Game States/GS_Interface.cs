using UnityEngine;
using System.Collections;

public interface GS_Interface{
	void StartState();
	void Update();
	void ExitState();
	
	bool IsFinished();
	GS_Interface GetNextGameState();
}