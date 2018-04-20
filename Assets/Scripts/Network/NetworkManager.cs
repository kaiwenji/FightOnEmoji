using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {
    const string VERSION = "v0.0.1";
    public string roomName = "test";
    public string prefabName = "frog";
    public string circlePrefab = "Circle";
    public string gameControlPrefab = "GameControl";
    public Transform startPoint1, startPoint2, startPoint3, startPoint4;
	// Use this for initialization
	void Start () {
        Debug.Log("connect to server");
        PhotonNetwork.ConnectUsingSettings(VERSION);
	}

    void OnJoinedLobby()
    {
        Debug.Log("in lobby");
        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = false,
            MaxPlayers = 4
        };
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }
    void OnJoinedRoom()
    {
        
        
        int index = PhotonNetwork.player.ID;
        Debug.Log("instantiate a new role: " + index);
        if (index == 1)
        {
            PhotonNetwork.Instantiate(prefabName, startPoint1.position, startPoint1.rotation, 0);
        }
        else if(index == 2)
        {
            PhotonNetwork.Instantiate(prefabName, startPoint2.position, startPoint2.rotation, 0);
        }
        else if(index == 3)
        {
            PhotonNetwork.Instantiate(prefabName, startPoint3.position, startPoint3.rotation, 0);
        }
        else
        {
            PhotonNetwork.Instantiate(prefabName, startPoint4.position, startPoint4.rotation, 0);
        }
    }
    void OnCreatedRoom()
    {
        PhotonNetwork.Instantiate(circlePrefab, new Vector3(), new Quaternion(), 0);
        PhotonNetwork.Instantiate(gameControlPrefab, new Vector3(), Quaternion.identity, 0);
    }
	
}
