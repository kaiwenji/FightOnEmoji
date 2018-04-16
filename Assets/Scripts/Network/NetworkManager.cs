using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {
    const string VERSION = "v0.0.1";
    public string roomName = "test";
    public string prefabName = "frog";
    public string circlePrefab = "Circle";
    public string gameControlPrefab = "GameControl";
    public Transform startPoint1, startPoint2;
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
            MaxPlayers = 6
        };
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }
    void OnJoinedRoom()
    {
        Debug.Log("instantiate a new role");
        if (PhotonNetwork.isMasterClient)
        {
            PhotonNetwork.Instantiate(prefabName, startPoint2.position, startPoint2.rotation, 0);
        }
        else
        {
            PhotonNetwork.Instantiate(prefabName, startPoint1.position, startPoint1.rotation, 0);
        }
    }
    void OnCreatedRoom()
    {
        PhotonNetwork.Instantiate(circlePrefab, new Vector3(), new Quaternion(), 0);
        PhotonNetwork.Instantiate(gameControlPrefab, new Vector3(), Quaternion.identity, 0);
    }
	
}
