using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    DoorManager door;
    Transform parent;
    characterController player;


    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        door = parent.Find("Door").GetComponent<DoorManager>();

        player = GameObject.Find("Player").GetComponent<characterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.pressedSpace == true && door.inRange == true)
        {
            door.up = true;
            player.pressedSpace = false;
        }
    }

    void OnTriggerEnter()
    {
        door.inRange = true;
    }

    void OnTriggerExit()
    {
        door.inRange = false;
        door.up = false;
    }
}
