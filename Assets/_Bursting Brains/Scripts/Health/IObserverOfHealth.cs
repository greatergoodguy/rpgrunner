using UnityEngine;
using System.Collections;

public interface IObserverOfHealth {
	void onHealthReducedByOne();
	void onHealthEmpty();
}
