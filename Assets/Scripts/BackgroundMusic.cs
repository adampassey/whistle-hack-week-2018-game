using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

	public static BackgroundMusic Instance;

	// Use this for initialization
	void Start () {
		if (Instance != null) {
			Destroy (gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
