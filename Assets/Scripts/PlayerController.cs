using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public KeyCode UpKey = KeyCode.W;
	public KeyCode DownKey = KeyCode.S;
	public KeyCode LeftKey = KeyCode.A;
	public KeyCode RightKey = KeyCode.D;
	private PlayerMovement PlayerMover;

	// Use this for initialization
	void Start () {
		PlayerMover = GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 direction = Vector2.zero;

		if (Input.GetKey (LeftKey)) {
			direction.x -= 1;
		}

		if (Input.GetKey (RightKey)) {
			direction.x += 1;
		}

		if (Input.GetKey (UpKey)) {
			direction.y += 1;
		}

		if (Input.GetKey (DownKey)) {
			direction.y -= 1;
		}

		PlayerMover.Move (direction);
	}
}
