using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLocationSpawn : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 minCoordinates;
    public Vector3 maxCoordinates;
    void Start()
    {
        transform.position = new Vector3(Random.Range(minCoordinates.x, maxCoordinates.x),
                                         Random.Range(minCoordinates.y, maxCoordinates.y),
                                         Random.Range(minCoordinates.z, maxCoordinates.z));
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
