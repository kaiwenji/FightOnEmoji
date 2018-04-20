using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public static string SceneNum;

	public void OnePlayerGame() {
		SceneNum = "one";
		SceneManager.LoadScene (2);
	}

	public void TwoPlayerGame() {
		SceneNum = "two";
		SceneManager.LoadScene (4);
		Debug.Log ("Loading two players beginnig menu...");

	}

	public void QuitGame() {
		Debug.Log ("QUIT!");
		Application.Quit ();
	}
}
