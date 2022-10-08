using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class textDetector : MonoBehaviour
{
    public Text textField;
    public Text chat;
    public InputField inputfield;
    private int textspamdelay = 60;
    private int spamcounter = 0;
    private int randomnicknumber = 0;

    public GameObject trgd;
    public bool isStartedToCount;
    public int removeSCH = 400;
    private int remov;

    void OnGUI()
    {
        if (!photonView.IsMine)
        {
            foreach (GameObject plyr in playerStuff.players)
            {
                if (plyr.GetComponent<PhotonView>().IsMine)
                {
                    trgd.transform.parent.transform.LookAt(plyr.transform.position);
                    trgd.transform.parent.transform.localEulerAngles += new Vector3(0, 180, 0);
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Return) && photonView.IsMine)
        {
            if (inputfield.isFocused && spamcounter >= textspamdelay)
            {
                if (!(textField.text.Length > 0))
                {
                    return;
                }
                
                Debug.Log(textField.text);
                OnGetMessage(textField.text);
                inputfield.text = "";
                spamcounter = 0;
            }
        } 
    }
    
    public PhotonView photonView;

    public void Start()
    {
        textField = PhotonChatManager.photonmanager.textchat;
        inputfield = PhotonChatManager.photonmanager.textField;
        chat = PhotonChatManager.photonmanager.chat;

        PhotonChatManager.photonmanager.gameObject.SetActive(false);

        randomnicknumber = UnityEngine.Random.Range(1, 100);
    }

    public void OnGetMessage(String text)
    {

        photonView.RPC("RPC_AddNewMessage", RpcTarget.AllBuffered, text, randomnicknumber);
    }

    public void AddBubble(string msg)
    {
        trgd.GetComponent<Text>().text = msg;
        trgd.SetActive(true);
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(trgd);
        } else if (stream.IsReading)
        {
            trgd.SetActive((bool)stream.ReceiveNext());
        }
    }

    [PunRPC]
    private void RPC_AddNewMessage(string msg, int randomnicknmb)
    {
        GameObject player = gameObject;
        int rnd = randomnicknmb;
        
        AddBubble(msg);

        player.GetComponent<referanceManager>().textdata.Add("[" + rnd + "] " + msg);
        ChatSubmit("[" + rnd + "] " + msg);
    }
    

    public int refreshDelay = 60;
    private int delaycounter = 0;


    public void ChatSubmit(string text)
    {
        if (chat == null)
        {
            return;
        }

        chat.text += text + "\n";
        
    }

    private void Update()
    {
        if (!PhotonChatManager.photonmanager.gameObject.activeSelf)
        {
            PhotonChatManager.photonmanager.gameObject.SetActive(true);
        }
        
        if (trgd != null && !isStartedToCount)
        {
            isStartedToCount = true;
        }

        if (isStartedToCount)
        {
            remov++;
        }

        if (remov >= removeSCH)
        {
            //trgd.gameObject.SetActive(false);
            trgd.GetComponent<Text>().text = "";
            trgd.SetActive(false);
            //trgd = null;
            remov = 0;
            isStartedToCount = false;
        }
        
        spamcounter++;
        
    }
}
