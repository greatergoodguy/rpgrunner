using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlAtObservers : PlAt_Base {

	IList<IObserverOfPlayer> observers = new List<IObserverOfPlayer>();

	public PlAtObservers() {}

	public void Add(IObserverOfPlayer observer) {
		observers.Add(observer);
	}

	public void NotifyOnReceiveOneDamage() {
		foreach(IObserverOfPlayer observer in observers) {
			observer.OnReceiveOneDamage();
		}
	}
}
