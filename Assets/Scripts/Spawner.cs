using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int numObjects = 100;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Spawn();
        }

    }

    void Spawn() {
        for (int i = 0; i < numObjects; i++)
        {
            GameObject.Instantiate<GameObject>(objectToSpawn);
        }
    }
}
