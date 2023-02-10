using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class characterController : MonoBehaviour
{
    float speed = 5.0f; // units per frame

    GameObject player;

    public GameObject messageObject;
    public TextMeshProUGUI messageText;
    public GameObject counterObject;
    public TextMeshProUGUI counterText;
    public Vector3 respawn;
    public bool pressedSpace = false;
    public string message;
    public int points = 0;

    Color lerpedColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        respawn = player.transform.position;

        messageObject = GameObject.Find("Canvas/playerMessage");
        messageText = messageObject.GetComponent<TextMeshProUGUI>();

        counterObject = GameObject.Find("Canvas/counter");
        counterText = counterObject.GetComponent<TextMeshProUGUI>();
        counterText.text = "Points: " + points;
        counterObject.transform.position = new Vector3(110, 20, 0);
        counterText.color = new Color32(0, 0, 0, 255);

        message = "WASD to Move, Q&E to Rotate, Space to Interact";
        ShowText();
        ShowPoints();
    }

    public void ShowText()
    {
        messageText.text = message;
        messageObject.SetActive(true);
        Invoke("HideText", 3);

    }

    public void ShowPoints()
    {
        counterText.text = "Points: " + points;
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
            points++;
            
            ShowPoints();
        }
    }
}
