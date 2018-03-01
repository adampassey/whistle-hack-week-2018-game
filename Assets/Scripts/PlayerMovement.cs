using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float Speed = 1.0f;
	public GameObject Sprite;
    public string UpAnimation = "knight-animation-walk-up";
    public string DownAnimation = "knight-animation-walk-down";
    public string LeftAnimation = "knight-animation-walk-left";
    public string RightAnimation = "knight-animation-walk-left";
    public string IdleAnimation = "knight-animation-idle";

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
			anim.Play (UpAnimation);
		} else if (direction.y < 0) {
			anim.Play (DownAnimation);
		} else if (direction.x < 0) {
			anim.Play (LeftAnimation);
			renderer.flipX = false;
		} else if (direction.x > 0) {
			anim.Play (RightAnimation);
			renderer.flipX = true;
		} else {
			anim.Play (IdleAnimation);
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

	public void PlayIdle() {
		anim.Play (IdleAnimation);
	}
}
