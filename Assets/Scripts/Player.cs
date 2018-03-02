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
			//arrow = Instantiate (ArrowPrefab);
			//	no longer instantiating arrows
			arrow = ArrowPrefab;
			arrow.transform.position = transform.position;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (HasWhistle && !GameState.Instance.GameOver) {
			Vector3 rotDir = (transform.position - Target.transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation(rotDir, Vector3.forward);
			lookRotation.x = 0f;
			lookRotation.y = 0f;
			arrow.transform.rotation = lookRotation;

			//arrow.transform.Translate (arrow.transform.forward * 2);
			arrow.transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, 0.3f);

		}
	}

	public void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject == null || Target.gameObject == null) {
			return;
		}
		if (coll.gameObject.name == Target.gameObject.name) {
			if (coll.gameObject == null)
				return;

			gameObject.GetComponent<PlayerController> ().enabled = false;

			Target.gameObject.GetComponent<PlayerMovement> ().PlayIdle ();
			GameObject dogSprite = Target.gameObject.transform.Find ("Sprite").gameObject;
			dogSprite.transform.SetParent (transform);
			dogSprite.transform.localPosition = new Vector2 (0f, 0.295f);
			GameObject.Destroy (coll.gameObject);

			PlayerMovement m = GetComponent<PlayerMovement> ();
			m.PlayIdle ();
			m.Move (Vector2.zero);

			GameObject.Destroy (arrow);

			GameState.Instance.Win (gameObject.name);
		}
	}
}
