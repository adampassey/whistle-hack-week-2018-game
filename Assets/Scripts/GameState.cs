using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

	public static GameState Instance;

	public GameObject SplashScreenObject;
	public GameObject MainCamera;
	public GameObject ActorObject;
	public GameObject StartScreenObject;
	public GameObject Splitter;
	public GameObject GameOverScreen;
	public GameObject WinText;

	public GameObject PlayerOne;
	public GameObject PlayerTwo;
	public GameObject PlayerTwoAI;

	public GameObject PlayerTwoCamera;

	public bool GameOver = false;

	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame(bool AI = false) {
		MainCamera.SetActive (false);
		SplashScreenObject.SetActive (false);
		StartScreenObject.SetActive (false);
		ActorObject.SetActive (true);
		Splitter.SetActive (true);

		GameObject p = PlayerTwo;

		//	only player 2 is considered for Whistle if no AI
		int playerWithWhislte = Random.Range (1, 3);
		if (AI) {
			p = PlayerOne;
		} else {
			if (playerWithWhislte == 1) {
				p = PlayerOne;
			} else {
				p = PlayerTwo;
			}
		}

		p.transform.Find ("Whistle").gameObject.SetActive (true);
		p.GetComponent<Player> ().HasWhistle = true;
	}

	public void ActivateActors() {
		ActorObject.SetActive (true);
	}

	public void RestartGame() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void StartGameOnePlayer() {
		StartGame (true);
		PlayerTwoCamera.GetComponent<CameraController> ().Target = PlayerTwoAI.transform;
		Destroy (PlayerTwo.gameObject);
	}

	public void StartGameTwoPlayer() {
		StartGame (false);
		Destroy (PlayerTwoAI.gameObject);
	}

	public void Win(string playerName) {
		GameOver = true;

		//	I would never normally do this but I don't
		//	have time for anything else. sue me.

		PlayerOne.GetComponent<PlayerController> ().enabled = false;
		if (PlayerTwo != null) {
			PlayerController two = PlayerTwo.GetComponent<PlayerController> ();
			if (two != null) {
				two.enabled = false;
				PlayerTwo.GetComponent<PlayerMovement> ().Move (Vector2.zero);
				PlayerTwo.GetComponent<PlayerMovement> ().PlayIdle ();
			}
		}

		if (PlayerTwoAI != null) {
			PlayerController twoAI = PlayerTwoAI.GetComponent<PlayerController> ();
			if (twoAI != null) {
				twoAI.enabled = false;
				PlayerTwoAI.GetComponent<PlayerMovement> ().Move (Vector2.zero);
				PlayerTwoAI.GetComponent<PlayerMovement> ().PlayIdle ();
			}
		}

		GameOverScreen.SetActive (true);
		WinText.GetComponent<Text> ().text = playerName + " has found their dog!";

	}
}
