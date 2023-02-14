using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    // GameObject destination;
    GameObject tp;
    Vector3 destination_coords;

    [HideInInspector]
    public Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        destination = this.gameObject.transform.GetChild(0);
        destination_coords = new Vector3(destination.transform.position.x + 1f, destination.transform.position.y + 0.6f, destination.transform.position.z - 1f);
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
    }
}
