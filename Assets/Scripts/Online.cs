using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Online : MonoBehaviourPunCallbacks
{

    static GameObject online;
    private void Awake()
    {
        if (online == null)
        {
            online = this.gameObject;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(online);
        }

    }

    public void NetWorkInitialize()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster()");
        PhotonNetwork.JoinRoom("Default");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomFailed()");
        PhotonNetwork.CreateRoom("Default");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        PhotonNetwork.CreateRoom("Default");
    }

    public override void OnCreatedRoom()
    {
        PhotonNetwork.JoinRoom("Default");
    }
    public override void OnJoinedRoom()
    {
        Debug.Log(" OnJoinedRoom()");
        PhotonNetwork.LoadLevel("Online");
    }

}
