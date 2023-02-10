using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class characterController : MonoBehaviour
{
    float speed = 5.0f; // units per frame

    GameObject player;

    public TextMeshProUGUI messageText;
    public GameObject messageObject;
    public string message;

    [HideInInspector]
    public Vector3 respawn;
    public bool pressedSpace = false;

    Color lerpedColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        respawn = player.transform.position;

        message = "WASD to Move, Q&E to Rotate, Space to Interact";
        ShowText();
    }

    public void ShowText()
    {
        messageText.text = message;
        messageObject.SetActive(true);
        Invoke("HideText", 3);

    }

    public void HideText()
    {
        messageObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (pressedSpace == true) pressedSpace = false;

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

        if (Input.GetKey(KeyCode.Space))
        {
            pressedSpace = true;
        }

        lerpedColor = Color.Lerp(Color.blue, Color.green, Mathf.PingPong(Time.time, 1));
        GetComponent<Renderer>().material.color = lerpedColor;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            // count = count + 1;
            // 
            // SetCountText();
        }
    }
}
