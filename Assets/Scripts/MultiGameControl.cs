using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MultiGameControl : Photon.PunBehaviour
{
    public List<string> rankList = new List<string>();

    public static MultiGameControl instance;
    public bool gameOver;
    private bool youDied;
    public int numberOfAlive;
    private float startTime;
    public GUIStyle myStyle;
    public bool frogStop;
    public bool gameStart = false;
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
        frogStop = true;
        youDied = false;
        numberOfAlive = 0;
        myStyle.normal.textColor = Color.white;
        myStyle.fontSize = 60;
        myStyle.fontStyle = FontStyle.Bold;
        myStyle.alignment = TextAnchor.MiddleCenter;
        this.photonView.RPC("updatePlayerNumber", PhotonTargets.MasterClient);

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
        if (!gameStart)
        {
            res = "Wait For Your Opponents...";
        }
        if (gameOver)
        {
            res = "You Win!";
            if (youDied)
            {
                res = "You Lose!";
            }
            //Invoke("ReturnToMenu", 10f);
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

		//Ghost Mode: all buttons will be enabled
		GameObject fireButton = GameObject.FindWithTag("FireButton");
		fireButton.gameObject.SetActive (false); 
		GameObject emoji = GameObject.FindWithTag ("localPlayer");
        emoji.GetComponent<skillScript> ().bombBtn.enabled = false;
        emoji.GetComponent<skillScript> ().gumBtn.enabled = false;

        Debug.Log("is Died: " + youDied);
        this.photonView.RPC("tellGameOver", PhotonTargets.All, PhotonNetwork.player.name);
    }
    [PunRPC]
    public void tellGameOver(string name)
    {
        numberOfAlive--;
        rankList.Add(name);
        if (numberOfAlive <= 1)
        {
            Debug.Log("is Died: " + youDied);

            //显示排名
            GameObject canvas = GameObject.Find("Canvas");
            canvas.transform.Find("Rank").gameObject.SetActive(true);
            string[] rankString = { "1st: You-Know-Who", "2nd", "3rd", "4th" };
            GameObject.Find("RankText1").GetComponent<Text>().text = rankString[0];
            Debug.Log(GameObject.Find("RankText1").GetComponent<Text>().text);
            for (int i = 1; i <= rankList.Count + 1; i++)
            {
                //i=1, count = 3, index=2
                GameObject.Find("RankText" + (i + 1)).GetComponent<Text>().text = rankString[i] + ": " + rankList[rankList.Count - i];
            }

            gameOver = true;
        }
    }
    [PunRPC]
    public void updatePlayerNumber()
    {
        Debug.Log("set player number");
        numberOfAlive += 1;
        if (numberOfAlive >= 2)
        {
            this.photonView.RPC("startGame", PhotonTargets.All);
        }
        Debug.Log("number is" + numberOfAlive);
        this.photonView.RPC("setPlayerNumber", PhotonTargets.Others, numberOfAlive);
    }

    [PunRPC]
    public void startGame()
    {
        GameObject.FindWithTag("localPlayer").GetComponent<MultiHamaJump>().setName();
        this.gameStart = true;
        this.frogStop = false;
    }

    [PunRPC]
    public void setPlayerNumber(int number)
    {
        numberOfAlive = number;
    }
}
