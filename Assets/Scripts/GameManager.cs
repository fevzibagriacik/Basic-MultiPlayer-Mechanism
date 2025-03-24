using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public GameObject MultiPlayerMenu;
    public GameObject CreateMenu;
    public GameObject JoinMenu;
    public GameObject LoadingMenu;
    public ConnectToServer connectToServer;
    public void ToSinglePlayerScene()
    {
        SceneManager.LoadScene("SinglePlayerScene");
    }

    public void ToMultiPlayerMenu()
    {
        MultiPlayerMenu.SetActive(true);
    }

    public void BackMainMenu()
    {
        MultiPlayerMenu.SetActive(false);
        PhotonNetwork.Disconnect();
    }

    public void ToCreateMenu()
    {
        CreateMenu.SetActive(true);
        JoinMenu.SetActive(false);
    }

    public void CloseCreateMenu()
    {
        CreateMenu.SetActive(false);
    }

    public void ToJoinMenu()
    {
        JoinMenu.SetActive(true);
        CreateMenu.SetActive(false);
    }

    public void CloseJoinMenu()
    {
        JoinMenu.SetActive(false);
    }

    public void ToLoadingMenu()
    {
        LoadingMenu.SetActive(true);
        connectToServer.ConnectServer();
    }
}
