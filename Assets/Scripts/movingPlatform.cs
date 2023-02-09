using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public int speed = 1;
    public int distance = 5;
    bool goForward = true;

    public enum choices { Forward, Backward, Left, Right }; // build in Up and Down as well

    private Vector3 endPos = new Vector3(0, 0, 0);
    private Vector3 startPos = new Vector3(0, 0, 0);

    public choices direction;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = startPos;
        endPos.z = startPos.z + distance;
    }

    // Update is called once per frame
    void Update()
    {
        switch (direction)
        {
            case choices.Forward:
                endPos = startPos;
                endPos.z = startPos.z + distance;
                break;

            case choices.Backward:
                endPos = startPos;
                endPos.z = startPos.z - distance;
                break;

            case choices.Right:
                endPos = startPos;
                endPos.x = startPos.x + distance;
                break;

            case choices.Left:
                endPos = startPos;
                endPos.x = startPos.x - distance;
                break;
        }

        if (goForward == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * speed);
            if (transform.position == endPos) goForward = false;
        }

        if (goForward == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * speed);
            if (transform.position == startPos) goForward = true;

        }
    }
}
