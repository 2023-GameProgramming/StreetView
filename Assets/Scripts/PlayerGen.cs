using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGen : MonoBehaviour
{
    public GameObject Avartarfab;
       
    private void Awake()
    {
        if (PlayerManager.LocalPlayerInstance == null)
        {
            Vector3 pos = Vector3.zero;
            pos.x += Random.Range(-3, 3);
            PlayerManager.LocalPlayerInstance = PhotonNetwork.Instantiate(Avartarfab.name, pos, Quaternion.identity, 0);
        }
    }

    private void OnDestroy()
    {
        PhotonNetwork.Destroy(PlayerManager.LocalPlayerInstance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
