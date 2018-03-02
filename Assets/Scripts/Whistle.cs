﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whistle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Animator anim = GetComponent<Animator> ();
		anim.Play ("whistle-animation");
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void KillMePlease() {
		Destroy (gameObject);
	}
}
