using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject Target;
	public GameObject ArrowPrefab;
	public bool HasWhistle = false;

	private GameObject arrow;

	// Use this for initialization
	void Start () {
		if (HasWhistle) {
			arrow = Instantiate (ArrowPrefab);
			arrow.transform.position = transform.position;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (HasWhistle) {
			Vector3 rotDir = (transform.position - Target.transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation(rotDir, Vector3.forward);
			lookRotation.x = 0f;
			lookRotation.y = 0f;
			arrow.transform.rotation = lookRotation;

			//arrow.transform.Translate (arrow.transform.forward * 2);
			arrow.transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, 0.3f);

		}
	}
}
