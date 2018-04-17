using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chooseCharacter : MonoBehaviour {

	public void brown(){
		PlayerPrefs.SetString ("character","brownb");
		if (MainMenu.SceneNum == "one") {
			SceneManager.LoadScene (1);
		} else {
			Debug.Log ("loading two players mode...");
			//SceneManager.LoadScene (1);
		}

	}

	public void sally(){
		PlayerPrefs.SetString ("character","sally");
		if (MainMenu.SceneNum == "one") {
			SceneManager.LoadScene (1);
		} else {
			Debug.Log ("loading two players mode...");
			//SceneManager.LoadScene (1);
		}
	}

	public void cony(){
		PlayerPrefs.SetString ("character","cony");
		if (MainMenu.SceneNum == "one") {
			SceneManager.LoadScene (1);
		} else {
			Debug.Log ("loading two players mode...");
			//SceneManager.LoadScene (1);
		}
	}

	public void leonard(){
		PlayerPrefs.SetString ("character","leonardf");
		if (MainMenu.SceneNum == "one") {
			SceneManager.LoadScene (1);
		} else {
			Debug.Log ("loading two players mode...");
			//SceneManager.LoadScene (1);
		}
	}
}
