using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public bool doesItHoldSomething = false;
    public GameObject gmitHolds;

    public Transform slotPosition;

    public Sprite fillIMG;

    public Sprite normalimg;
    // Start is called before the first frame update
    void Start()
    {
        normalimg = gameObject.GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (doesItHoldSomething)
        {
            gameObject.GetComponent<Image>().sprite = fillIMG;
        } else if (!doesItHoldSomething)
        {
            gameObject.GetComponent<Image>().sprite = normalimg;
        }
    }
}
