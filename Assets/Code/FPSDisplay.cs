using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
 
public class FPSDisplay : MonoBehaviour
{
	private List<ParticleSystem> testParticleSystems = new List<ParticleSystem> ();
	float deltaTime = 0.0f;

	void Start() {
		// find the active partcile system
		foreach (GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects()) {
			if (obj.activeSelf == true) {
				ParticleSystem[] systems = obj.GetComponentsInChildren<ParticleSystem> ();
				testParticleSystems.AddRange (systems);
			}
		}
	}
 
	void Update()
	{
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
	}
 
	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;
 
		GUIStyle style = new GUIStyle();


		int nParticles = 0;
		foreach (ParticleSystem system in testParticleSystems) {
			nParticles += system.maxParticles;
		}
 
		Rect rect = new Rect(0, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 2 / 100;
		style.normal.textColor = Color.red;
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		string text = string.Format("{0:0.0} ms ({1:0.} fps) ({2} max particles)", msec, fps, nParticles);
		GUI.Label(rect, text, style);
	}
}