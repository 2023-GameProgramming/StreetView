using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Send : MonoBehaviourPunCallbacks
{
    public GameObject content;
    public InputField input;
    public GameObject chatPrefab;
    public Scrollbar scrollbar;
    // Start is called before the first frame update
    void Start()
    {
        input.text = "";
        GetComponent<Button>().onClick.AddListener(CrateChat);
    }


    [PunRPC]
    void CreateChatRpc(string text)
    {
        //GameObject obj = PhotonNetwork.Instantiate(chatPrefab.name, chatPrefab.transform.position, Quaternion.identity, 0);
        GameObject obj = GameObject.Instantiate<GameObject>(chatPrefab);
        obj.transform.SetParent(content.transform);
        obj.GetComponent<Text>().text = text;
        RectTransform chatRect = chatPrefab.GetComponent<RectTransform>();
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(chatRect.sizeDelta.x, content.transform.childCount * chatRect.sizeDelta.y);
        scrollbar.value = 0;
    }


    void CrateChat()
    {
        if (input.text != "")
        {
            this.photonView.RPC("CreateChatRpc", RpcTarget.All, input.text);
        }
        input.text = "";
    }



}
