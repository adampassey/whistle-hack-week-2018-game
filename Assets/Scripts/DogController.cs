using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour {

    public float ChangeDirectionTime = 5.0f;
    private Vector2 moveDirection = Vector2.zero;
    private float lastTimeChange;
    private PlayerMovement movement;

	// Use this for initialization
	void Start () {
        movement = GetComponent<PlayerMovement>();
        lastTimeChange = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > lastTimeChange + ChangeDirectionTime) {
            changeDirection();
        }
        movement.Move(moveDirection);
	}

    private void changeDirection() {
        int y = Random.Range(-1, 2);
        int x = Random.Range(-1, 2);
        moveDirection = new Vector2(x, y);

        lastTimeChange = Time.timeSinceLevelLoad;
    }
}
