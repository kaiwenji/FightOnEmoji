using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MultiGameControl : Photon.PunBehaviour {
    public static MultiGameControl instance;
    public bool gameOver;
    private float startTime;
    public GUIStyle myStyle;
    public bool hostWin;
    public bool frogStop;
    //public GameObject terminalObj;
	// Use this for initialization
	void Awake () {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        gameOver = false;
        hostWin = false;
        frogStop = false;
        myStyle.normal.textColor = Color.white;
        myStyle.fontSize = 60;
        myStyle.fontStyle = FontStyle.Bold;
        myStyle.alignment = TextAnchor.MiddleCenter;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            Time.timeScale = 0f;
            //StartCoroutine(reload());
        }


    }
    private void OnGUI()
    {
        if (gameOver)
        {
            string res = "You Lose!";
            if (!hostWin)
            {
                res = "You Win!";
            }
            GUI.Box(new Rect(325, -325, Screen.height, Screen.width), res, myStyle);
        }
    }
    public void GameOver()
    {
        this.photonView.RPC("rpcEndGame", PhotonTargets.All);
        hostWin = false;
        this.photonView.RPC("setWinner", PhotonTargets.Others, true);

    }
    [PunRPC]
    public void setWinner(bool hostWin)
    {
        this.hostWin = hostWin;
    }
    [PunRPC]
    public void rpcEndGame()
    {
        gameOver = true;
        frogStop = true;
    }


    IEnumerator reload()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("frog_kevin");
    }

    public void startVs()
    {
        frogStop = true;
        GameObject vs = GameObject.Find("VersusSystem");
        vs.GetComponent<VersusScript>().startFight();
    }
    public void endVs()
    {
        //GameObject go = GameObject.FindWithTag("Player");
        //go.GetComponent<MultiHamaJump>().checkWhoWin(isMasterWin);
        frogStop = false;
    }
}
