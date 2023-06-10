using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenFuction : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void openCanvas()
    {
        canvas.gameObject.SetActive(true);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("InScene");
    }
}
