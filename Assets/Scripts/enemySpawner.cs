using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy, new Vector3(18, 1, 48), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
