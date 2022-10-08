using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class textManager : MonoBehaviour
{
    /*public List<String> messages = new List<string>();
    private List<GameObject> playerlist = new List<GameObject>();
    public PhotonView photonView;
    public Text textField;

    public void SetClientList(List<GameObject> playerList)
    {
        playerlist = playerList;
    }

    private void Start()
    {
        throw new NotImplementedException();
    }

    public void OnGetMessage(String text)
    {
        messages.Add(text);
        photonView.RPC("RPC_AddNewMessage", RpcTarget.AllBuffered, text);
    }

    [PunRPC]
    private void RPC_AddNewMessage(string msg)
    {
        GameObject player = gameObject;
        
        int playernmb = 0;
        playernmb++;
        player.GetComponent<referanceManager>().textdata.Add("[" + playernmb + "] " + msg);
        ChatRefresh();
        
    }
    

    public int refreshDelay = 60;
    private int delaycounter = 0;
    
    public void ChatRefresh()
    {
        textField.text = "";
        foreach (string text in messages) {
            textField.text += text + "\n";
        }
    }

    private void Update()
    {
        delaycounter++;

        if (delaycounter >= refreshDelay)
        {
            ChatRefresh();
        }
    }*/
}
