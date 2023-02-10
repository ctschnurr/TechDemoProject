using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    bool respawnCheck;
    GameObject pickUpObject;
    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        pickUpObject = parent.transform.Find("PickUpObject").gameObject;
        respawnCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpObject.activeSelf == false && respawnCheck == false)
        {
            Invoke("Respawn", 5);
            respawnCheck = true;
        }
    }

    void Respawn()
    {
        pickUpObject.SetActive(true);
        respawnCheck = false;
    }
}
