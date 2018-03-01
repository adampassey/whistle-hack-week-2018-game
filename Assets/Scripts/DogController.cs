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
        ChangeDirectionTime = Random.Range(3.0f, 7.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > lastTimeChange + ChangeDirectionTime || lastTimeChange == 0) {
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
