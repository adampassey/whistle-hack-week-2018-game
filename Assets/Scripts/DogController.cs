using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour {

    public float ChangeDirectionTime = 5.0f;
    public Vector2 moveDirection = Vector2.zero;
	public bool RandomStart = false;
    private float lastTimeChange;
    private PlayerMovement movement;

	// Use this for initialization
	void Start () {
        movement = GetComponent<PlayerMovement>();
        lastTimeChange = 0;
        ChangeDirectionTime = Random.Range(1.0f, 5.0f);
		movement.Move (Vector2.zero);

		if (RandomStart) {
			Transform[] dogSpawns = DogSpawns.Instance.SpawnPoints;

			int index = Random.Range (0, dogSpawns.Length - 1);
			Vector2 startingPos = dogSpawns [index].position;

			transform.position = startingPos;
			lastTimeChange = Time.timeSinceLevelLoad;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > lastTimeChange + ChangeDirectionTime || lastTimeChange == 0) {
            changeDirection();
        }
        movement.Move(moveDirection);
	}

    private void changeDirection() {

		Vector2 newPos = Vector2.zero;

		newPos.x = Random.Range (-1, 1);
		newPos.y = Random.Range (-1, 1);

		moveDirection = newPos;

        lastTimeChange = Time.timeSinceLevelLoad;
    }

	public void OnCollisionEnter2D(Collision2D coll) {
		moveDirection.x = -moveDirection.x;
		moveDirection.y = -moveDirection.y;
	}
}
