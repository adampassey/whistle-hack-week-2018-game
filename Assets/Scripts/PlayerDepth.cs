using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDepth : MonoBehaviour {

    private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		renderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        renderer.sortingOrder = -Mathf.RoundToInt(transform.position.y * 1000);
	}
}
