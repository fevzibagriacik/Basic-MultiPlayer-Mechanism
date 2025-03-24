using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public GameObject MainMenu;
    public GameObject MultiPlayerMenu;
    public void ConnectServer()
    {
        MainMenu.SetActive(false);
        PhotonNetwork.PhotonServerSettings.AppSettings.BestRegionSummaryFromStorage = null;
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting to the server...");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("Connecting to the lobby...");
    }

    public override void OnJoinedLobby()
    {
        gameObject.SetActive(false);
        Debug.Log("Joined to the lobby.");
        MainMenu.SetActive(true);
        MultiPlayerMenu.SetActive(true);
    }
}
