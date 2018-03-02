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

		if (Random.Range (1, 3) == 1) {
			p = PlayerOne;
		}

		p.GetComponent<Player> ().HasWhistle = true;

		if (!AI) {
			p.transform.Find ("Whistle").gameObject.SetActive (true);
		} else {
			PlayerTwoAI.transform.Find ("Whistle").gameObject.SetActive (true);
		}
	}

	public void ActivateActors() {
		ActorObject.SetActive (true);
	}

	public void RestartGame() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void StartGameOnePlayer() {
		StartGame ();
		PlayerTwoCamera.GetComponent<CameraController> ().Target = PlayerTwoAI.transform;
		Destroy (PlayerTwo.gameObject);
	}

	public void StartGameTwoPlayer() {
		StartGame ();
		Destroy (PlayerTwoAI.gameObject);
	}

	public void Win(string playerName) {
		GameOver = true;

		PlayerOne.GetComponent<PlayerController> ().enabled = false;
		if (PlayerTwo != null) {
			PlayerController two = PlayerTwo.GetComponent<PlayerController> ();
			if (two != null) {
				two.enabled = false;
			}
		}

		if (PlayerTwoAI != null) {
			PlayerController twoAI = PlayerTwoAI.GetComponent<PlayerController> ();
			if (twoAI != null) {
				twoAI.enabled = false;
			}
		}

//		PlayerTwo.GetComponent<PlayerController> ().enabled = false;
//		PlayerTwoAI.GetComponent<PlayerController> ().enabled = false;

		GameOverScreen.SetActive (true);
		WinText.GetComponent<Text> ().text = playerName + " wins!";

	}
}
