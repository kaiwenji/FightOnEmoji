using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetUserName : MonoBehaviour {

	    public void GetInput(string name) {
		        Debug.Log ("Your User Name is " + name);
		    }

	    public void StartButton() {
		        SceneManager.LoadScene (3);
		        Debug.Log ("Loading two players mode...");
		    }
}
