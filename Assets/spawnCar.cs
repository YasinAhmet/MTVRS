using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCar : MonoBehaviour
{
    public GameObject car;

    public int carS;

    private int c;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        c++;

        if (c >= carS)
        {
            GameObject carz = Instantiate(car);
            carz.transform.position = transform.position;
            carz.transform.rotation = transform.rotation;
            c = 0;
        }
    }
}
