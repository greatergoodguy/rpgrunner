using UnityEngine;
using System.Collections;

public static class FactoryOfAttacks {
	
	static GameObject goArrowWood = null;
	public static GameObject GetGOArrowWood(){
		GameObject result = GetGOProjectile(goArrowWood, "Arrow Wood");
		return result;
	}

	static GameObject goArrowMetal = null;
	public static GameObject GetGOArrowMetal() {
		GameObject result = GetGOProjectile(goArrowMetal, "Arrow Metal");
		return result;
	}

	static GameObject goArrowFire = null;
	public static GameObject GetGOArrowFire() {
		GameObject result = GetGOProjectile(goArrowFire, "Arrow Fire");
		return result;
	}

	static GameObject goArrowIce = null;
	public static GameObject GetGOArrowIce() {
		GameObject result = GetGOProjectile(goArrowIce, "Arrow Ice");
		return result;
	}

	// =====================
	// Private Methods
	// =====================
	public static GameObject GetGOProjectile(GameObject goMold, string name) {
		if(goMold == null){
			goMold = Resources_BB.Load(name);}

		Transform tProjectile = MonoBehaviour_BB.Instantiate(goMold.transform);
		AddComponentsForProjectile(tProjectile);

		return tProjectile.gameObject;
	}

	private static void AddComponentsForProjectile(Transform tProjectile) {
		tProjectile.gameObject.AddComponent<AIShortLife>();
		tProjectile.gameObject.AddComponent<AIProjectile>();
	}
}