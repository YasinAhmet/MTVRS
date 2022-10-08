using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Photon.Pun;
using UnityEngine;

public class playerStuff : MonoBehaviour
{
    public static List<GameObject> players = new List<GameObject>();
    public GameObject PlayerOBJ;
    public GameObject playerObj2;
    
    void Start()
    {
        int rg = Random.Range(0, 2);
        GameObject gmo;
        if (rg == 1)
        {
            gmo = PhotonNetwork.Instantiate(PlayerOBJ.name, PlayerOBJ.transform.position, new Quaternion());
            gmo.GetComponent<PhotonView>().ObservedComponents.Add(playerObj2.GetComponent<PhotonView>());
        }
        else
        {
            gmo = PhotonNetwork.Instantiate(playerObj2.name, playerObj2.transform.position, new Quaternion());
            gmo.GetComponent<PhotonView>().ObservedComponents.Add(PlayerOBJ.GetComponent<PhotonView>());
        }

        players.Add(gmo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
