using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class BackMainMenu : MonoBehaviourPunCallbacks
{
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
        PhotonNetwork.Disconnect();
    }

    public void BackFromSinglePlayer()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
