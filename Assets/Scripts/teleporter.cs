using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    GameObject destination;
    Vector3 destination_coords;

    // Start is called before the first frame update
    void Start()
    {
        destination = GameObject.Find("Destination");
        destination_coords = destination.transform.position;

        Debug.Log(destination_coords);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.position = destination_coords;
        }

        Debug.Log(destination_coords);
    }
}
