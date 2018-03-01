using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDepth : MonoBehaviour {

    private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
        renderer = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        renderer.sortingOrder = -Mathf.RoundToInt(transform.position.y * 1000);
	}
}
