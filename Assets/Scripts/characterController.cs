using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    float speed = 5.0f; // units per frame

    GameObject player;
    public Vector3 respawn;

    Color lerpedColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        respawn = player.transform.position;
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
            transform.Translate(0, 0, vert);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(horiz, 0, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0.0f, 0.5f, 0.0f);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0.0f, -0.5f, 0.0f);
        }

        lerpedColor = Color.Lerp(Color.green, Color.white, Mathf.PingPong(Time.time, 1));
        GetComponent<Renderer>().material.color = lerpedColor;


    }
}
