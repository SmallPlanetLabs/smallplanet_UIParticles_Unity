using UnityEngine;

public class PlanetUnityOverrides : MonoBehaviour, IPUCode {

	public void Awake() {
		PlanetUnityOverride.ForceActualSprites = true;
	}
	
}