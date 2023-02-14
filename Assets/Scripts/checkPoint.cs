using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    characterController player;
    GameObject parent;
    GameObject checkOn;
    GameObject checkOff;
    Vector3 respawnPoint;

    Vector3 sizeUp;
    Vector3 sizeDown;

    static GameObject previous;

    Color lerpedColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<characterController>();

        parent = transform.parent.gameObject;
        checkOn = parent.transform.Find("CheckOn").gameObject;
        checkOff = parent.transform.Find("CheckOff").gameObject;
        respawnPoint = new Vector3(parent.transform.position.x + 1f, parent.transform.position.y + 0.6f, parent.transform.position.z - 1f);

        previous = parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkOn.activeSelf == true)
        {
            lerpedColor = Color.Lerp(Color.green, Color.black, Mathf.PingPong(Time.time, 1));
            GetComponent<Renderer>().material.color = lerpedColor;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (previous != parent && previous != checkOn) previous.SetActive(false);

            if (checkOff.activeSelf == true)
            {
                player.respawn = respawnPoint;
                checkOff.SetActive(false);
                checkOn.SetActive(true);

                previous = checkOn;

                player.message = "Checkpoint!";
                player.ShowText();
            }
        }
    }
}
