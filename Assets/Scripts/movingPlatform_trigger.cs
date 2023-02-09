using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform_trigger : MonoBehaviour
{
    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
         platform = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.SetParent(platform.transform);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;

        }
    }
}
