using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool paused = false;

	public GameObject pauseMenuUI;

	public void PauseGame() {
		paused = true;
		PauseIt ();
	}

	void PauseIt() {
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		paused = true;
	}

	public void ResumeIt() {
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		paused = false;
	}

	public void LoadMenu() {
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Menu");
	}

	public void QuitGame() {
		Debug.Log ("Quitting Game...");
		Application.Quit ();
	}
}
