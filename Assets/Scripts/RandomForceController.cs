using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForceController : MonoBehaviour
{
    public Rigidbody rigidBodyRef;
    public float minForce = 5;
    public float maxForce = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ApplyRandomForce();
        }
    }

    void ApplyRandomForce() {
        rigidBodyRef.AddForce(new Vector3(Random.Range(minForce, maxForce), Random.Range(minForce, maxForce), Random.Range(minForce, maxForce)));
    }
}
