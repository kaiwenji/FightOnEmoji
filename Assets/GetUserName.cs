using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetUserName : MonoBehaviour {
	public static string username;
    public void GetInput(string name) {
		username = name;
        Debug.Log ("Your User Name is " + name);
    }

    public void StartButton() {
        SceneManager.LoadScene (3);
        Debug.Log ("Loading two players mode...");
	}
}
