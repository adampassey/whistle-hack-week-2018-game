using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour {

    public float ChangeDirectionTime = 5.0f;
    public Vector2 moveDirection = Vector2.zero;
    private float lastTimeChange;
    private PlayerMovement movement;

	// Use this for initialization
	void Start () {
        movement = GetComponent<PlayerMovement>();
        lastTimeChange = 0;
        ChangeDirectionTime = Random.Range(3.0f, 7.0f);
		movement.Move (Vector2.zero);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > lastTimeChange + ChangeDirectionTime || lastTimeChange == 0) {
            changeDirection();
        }
        movement.Move(moveDirection);
	}

    private void changeDirection() {
		Vector3 newPos = new Vector3 (
			                 Random.Range (-6, 13),
			                 Random.Range (-9, 8),
							 0
		                 );
		moveDirection = (newPos - transform.position).normalized;

		if (Random.Range (0, 2) == 0) {
			moveDirection.x = -moveDirection.x;
		} 
		if (Random.Range (0, 2) == 0) {
			moveDirection.y = -moveDirection.y;
		}

        lastTimeChange = Time.timeSinceLevelLoad;
    }

	public void OnCollisionEnter2D(Collision2D coll) {
		moveDirection.x = -moveDirection.x;
		moveDirection.y = -moveDirection.y;
	}
}
