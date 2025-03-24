using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;

public class MultiPlayerManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomJoinInputField;
    public TMP_InputField roomCreateInputField;

    public GameObject createRoomMenu;
    public GameObject joinRoomMenu;

    private string createdRoomName;
    private string joinedRoomName;
    void Start()
    {
        Debug.Log("Connecting...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        Debug.Log("Connected to server.");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        Debug.Log("We're connected and in a room now.");
    }

    /*public void JoinRoom()
    {
        if(PhotonNetwork.CountOfRooms == 0 && roomJoinInputField.text == "Demo")
        {
            PhotonNetwork.CreateRoom("Demo");
            joinedRoomName = "Demo";
            return;
        }

        joinedRoomName = roomJoinInputField.text;

        if (!string.IsNullOrEmpty(joinedRoomName))
        {
            PhotonNetwork.JoinRoom(joinedRoomName);
            Debug.Log("Connecting to the " + joinedRoomName + "...");
        }
        else
        {
            Debug.Log("Please enter a room name!");
        }
    }

    public void CreateRoom()
    {
        createdRoomName = roomCreateInputField.text.Trim();

        if (!string.IsNullOrEmpty(createdRoomName))
        {
            PhotonNetwork.CreateRoom(createdRoomName, new RoomOptions { MaxPlayers = 4 });
            Debug.Log(createdRoomName + " is creating...");
            return;
        }

        Debug.Log("Please enter a room name!");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log(createdRoomName + " is created.");
        if (createRoomMenu.activeInHierarchy)
        {
            SceneManager.LoadScene("MultiPlayerScene"); //SpawnPoint will be added.
        }
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined to the " + joinedRoomName);
        SceneManager.LoadScene("MultiPlayerScene"); //SpawnPoint will be added.
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Fail entering to room: " + message);
    }*/

    public void ToCreateRoomMenu()
    {
        createRoomMenu.SetActive(true);
        joinRoomMenu.SetActive(false);
    }

    public void CloseCreateRoomMenu()
    {
        createRoomMenu.SetActive(false);
    }

    public void ToJoinRoomMenu()
    {
        joinRoomMenu.SetActive(true);
        createRoomMenu.SetActive(false);
    }

    public void CloseJoinRoomMenu()
    {
        joinRoomMenu.SetActive(false);
    }
}
