using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    float speed = 5.0f; // units per frame

    GameObject player;
    public Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        origin = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float vert = Input.GetAxis("Vertical") * speed;
        float horiz = Input.GetAxis("Horizontal") * speed;

        vert *= Time.deltaTime;
        horiz *= Time.deltaTime;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(0, 0, vert);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(horiz, 0, 0);
        }
    }
}
