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

	public bool GameOver = false;

	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame() {
		MainCamera.SetActive (false);
		SplashScreenObject.SetActive (false);
		StartScreenObject.SetActive (false);
		ActorObject.SetActive (true);
		Splitter.SetActive (true);
	}

	public void ActivateActors() {
		ActorObject.SetActive (true);
	}

	public void RestartGame() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void StartGameOnePlayer() {
		StartGame ();
	}

	public void StartGameTwoPlayer() {
		StartGame ();
	}

	public void Win(string playerName) {
		Debug.Log (playerName + " wins!");

		GameOver = true;

		PlayerOne.GetComponent<PlayerController> ().enabled = false;
		PlayerTwo.GetComponent<PlayerController> ().enabled = false;

		GameOverScreen.SetActive (true);
		WinText.GetComponent<Text> ().text = playerName + " wins!";
	}
}
