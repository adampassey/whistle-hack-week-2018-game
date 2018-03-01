using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float Speed = 1.0f;
	public GameObject Sprite;

	private Animator anim;
	private SpriteRenderer renderer;
	private Vector2 direction;

	// Use this for initialization
	void Start () {
		anim = Sprite.GetComponent<Animator> ();
		renderer = Sprite.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (direction.y > 0) {
			anim.Play ("knight-animation-walk-up");
		} else if (direction.y < 0) {
			anim.Play ("knight-animation-walk-down");
		} else if (direction.x < 0) {
			anim.Play ("knight-animation-walk-left");
			renderer.flipX = false;
		} else if (direction.x > 0) {
			anim.Play ("knight-animation-walk-left");
			renderer.flipX = true;
		} else {
			anim.Play ("knight-animation-idle");
		}

		if (direction.x != 0 & direction.y != 0) {
			direction.x = direction.x / 1.3f;
			direction.y = direction.y / 1.3f;
		}

		transform.Translate (direction * Speed * Time.deltaTime);
	}

	public void Move(Vector2 direction) {
		this.direction = direction;
	}
}
