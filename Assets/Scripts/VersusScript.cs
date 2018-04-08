using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersusScript : Photon.MonoBehaviour {
    public Vector2 buttonPos = new Vector2(1000, 500);
    public Rect label = new Rect(20, 20, 100, 100);
    public Texture2D buttonImg = null;
    public SimpleHealthBar healthBar;


    private Vector2 buttonSize;
    private GUIStyle fontStyle;
    private Texture2D background = null;
    private int counter = 1;
    private int enemyCounter = 1;
    private float startTime;
    private bool isStarted = false;
    // Use this for initialization
    void Start () {
        fontStyle = new GUIStyle();
        buttonSize = new Vector2(buttonImg.height, buttonImg.width);
        setBarColor();
        setFontStyle();
	}
	
	// Update is called once per frame
	void Update () {
        if (!PhotonNetwork.isMasterClient)
        {
            return;
        }
		if(isStarted && Time.time - startTime > 3f)
        {
            MultiGameControl.instance.endVs();
            this.photonView.RPC("endFight", PhotonTargets.All, counter > enemyCounter);
        }
	}
    [PunRPC]
    public void endFight(bool isMasterWin)
    {
        Debug.Log(isMasterWin);
        if(isMasterWin && !PhotonNetwork.isMasterClient)
        {
            GameObject.FindWithTag("localPlayer").GetComponent<MultiHamaJump>().stepBack();
        }
        if(!isMasterWin && PhotonNetwork.isMasterClient)
        {
            Debug.Log("master lose");
            GameObject.FindWithTag("localPlayer").GetComponent<MultiHamaJump>().stepBack();
        }
        isStarted = false;
    }
    [PunRPC]
    void sendCount(int count)
    {
        this.enemyCounter = count;
    }
    [PunRPC]
    public void startFight()
    {
        if (PhotonNetwork.isMasterClient)
        {
            this.photonView.RPC("startFight", PhotonTargets.Others);
            startTime = Time.time;
        }
        isStarted = true;
        counter = 1;
        enemyCounter = 1;
    }
    private void setFontStyle()
    {
        fontStyle.normal.textColor = Color.white;
        fontStyle.fontSize = 60;
        fontStyle.fontStyle = FontStyle.Bold;
        fontStyle.alignment = TextAnchor.MiddleCenter;
    }
    private void setBarColor()
    {
        background = new Texture2D(1, 1);
        background.SetPixel(0, 0, Color.blue);
        background.Apply();
    }
    private void OnGUI()
    {
        if (!isStarted)
        {
            return;
        }
        GUI.skin.box.normal.background = background;
        healthBar.UpdateBar(counter, counter + enemyCounter);
        //GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "1", fontStyle);
        if (GUI.Button(new Rect(buttonPos, buttonSize), buttonImg))
        {
            counter += 1;
            this.photonView.RPC("sendCount", PhotonTargets.Others, counter);
        }
    }
}
