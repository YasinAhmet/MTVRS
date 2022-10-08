using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class mouseMovement : MonoBehaviour
{
    public Transform playerBody;
    public PhotonView photonView;
	
    public float xRotation = 0f;
    public float rotationSpeed = 100f;

    void Update()
    {
        if (!photonView.IsMine)
        { 
            photonView.gameObject.transform.Find("Main Camera").gameObject.SetActive(false);
        }

        if (photonView.IsMine)
        {

            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
