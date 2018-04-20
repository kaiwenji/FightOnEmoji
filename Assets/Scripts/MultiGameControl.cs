using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MultiGameControl : Photon.PunBehaviour
{
    public static MultiGameControl instance;
    public bool gameOver;
    private bool youDied;
    public int numberOfAlive;
    private float startTime;
    public GUIStyle myStyle;
    public bool frogStop;
    //public GameObject terminalObj;
    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        gameOver = false;
        frogStop = false;
        youDied = false;
        numberOfAlive = 4;
        myStyle.normal.textColor = Color.white;
        myStyle.fontSize = 60;
        myStyle.fontStyle = FontStyle.Bold;
        myStyle.alignment = TextAnchor.MiddleCenter;
        //this.photonView.RPC("setPlayerNumber", PhotonTargets.All);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0f;
        }


    }
    private void OnGUI()
    {
        string res = numberOfAlive.ToString();
        if (gameOver)
        {
            res = "You Win!";
            if (youDied)
            {
                res = "You Lose!";
            }
        }
        GUI.Box(new Rect(325, -325, Screen.height, Screen.width), res, myStyle);
    }
    public void GameOver()
    {
        if (youDied)
        {
            return;
        }
        youDied = true;
        Debug.Log("is Died: " + youDied);
        this.photonView.RPC("tellGameOver", PhotonTargets.All);
    }
    [PunRPC]
    public void tellGameOver()
    {
        numberOfAlive--;
        if (numberOfAlive <= 1)
        {
            Debug.Log("is Died: " + youDied);
            gameOver = true;
        }
    }
    [PunRPC]
    public void setPlayerNumber()
    {
        Debug.Log("set player number");
        numberOfAlive = PhotonNetwork.countOfPlayersInRooms + 1;
        Debug.Log("number is" + numberOfAlive);
    }


}
