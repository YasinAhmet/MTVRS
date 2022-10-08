using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    public float speed;

    public int ds;

    private int d;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        d++;
        gameObject.transform.position += transform.right * Time.deltaTime * speed;

        if (d >= ds)
        {
            Destroy(gameObject);
        }
    }
}
