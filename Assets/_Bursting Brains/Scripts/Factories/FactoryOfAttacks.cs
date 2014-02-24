using UnityEngine;
using System.Collections;

public static class FactoryOfAttacks {
	
	static GameObject goFireball;
	public static GameObject GetGOFireball(){
		if(goFireball == null){
			goFireball = Resources.Load("Arrow Red 7") as GameObject;
			Assert_BB.AssertNotNull(goFireball);	
		}
		
		Transform tFireball = MonoBehaviour.Instantiate(goFireball.transform, Vector3.zero, Quaternion.identity) as Transform;
		Assert_BB.Assert(tFireball != null);
		
		return tFireball.gameObject;
	}
}