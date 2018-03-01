using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGenerator : MonoBehaviour {

	public float XSpace = 0.638f;
	public float YSpace = 0.569f;
	public int Count;
	public GameObject GrassPrefab;

	// Use this for initialization
	void Start () {
		for (int x = 0; x < Count; x++) {
			for (int y = 0; y < Count; y++) {
				GameObject grassTile = Instantiate (GrassPrefab);
				Vector2 pos = new Vector2 (x * XSpace, y * YSpace);
				grassTile.transform.position = pos;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
