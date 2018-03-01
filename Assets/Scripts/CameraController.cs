using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform Target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate() {
		Vector3 newPos = new Vector3 (Target.position.x, Target.position.y, -10f);
		transform.position = newPos;
	}
}
