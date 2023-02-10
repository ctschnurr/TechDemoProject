using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerV2 : MonoBehaviour
{
    public int speed = 1;

    GameObject doorL;
    GameObject doorR;
    GameObject parent;
    characterController player;

    private Vector3 goLeft = new Vector3(0, 0, 0);
    private Vector3 goRight = new Vector3(0, 0, 0);
    private Vector3 startLeft = new Vector3(0, 0, 0);
    private Vector3 startRight = new Vector3(0, 0, 0);

    bool inRange = false;
    bool goTime = false;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;

        doorL = parent.transform.Find("DoorL").gameObject;
        doorR = parent.transform.Find("DoorR").gameObject;

        startLeft = doorL.transform.position;
        startRight = doorR.transform.position;

        goLeft = startLeft;
        goRight = startRight;

        goLeft.x = startLeft.x - 1.3f;
        goRight.x = startRight.x + 1.3f;

        player = GameObject.Find("Player").GetComponent<characterController>();
    }

    // Update is called once per frame
    void Update()
    {
            
        if (player.pressedSpace == true && inRange == true)
        {
           goTime = true;
        }

        if (goTime == true)
        {
            doorL.transform.position = Vector3.MoveTowards(doorL.transform.position, goLeft, Time.deltaTime * speed);
            doorR.transform.position = Vector3.MoveTowards(doorR.transform.position, goRight, Time.deltaTime * speed);

            player.pressedSpace = false;
        }

        if (goTime == false)
        {
            doorL.transform.position = Vector3.MoveTowards(doorL.transform.position, startLeft, Time.deltaTime * speed);
            doorR.transform.position = Vector3.MoveTowards(doorR.transform.position, startRight, Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter()
    {
        inRange = true;
    }

    void OnTriggerExit()
    {
        inRange = false;
        goTime = false;
    }

}
