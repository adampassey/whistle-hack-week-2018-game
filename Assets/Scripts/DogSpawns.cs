using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSpawns : MonoBehaviour {

	public Transform[] SpawnPoints;
	public static DogSpawns Instance;

	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
