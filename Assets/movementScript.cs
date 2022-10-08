using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public float speed = 1f;
    
    void Update()
    {
        if (transform.GetComponent<PhotonView>().IsMine)
        {

            //MOVEMENT
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * Time.deltaTime * speed;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position += -transform.forward * Time.deltaTime * speed;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.position += -transform.right * Time.deltaTime * speed;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * Time.deltaTime * speed;
            }
        }
    }
}
