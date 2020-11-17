using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   // public Stack<Collider> balls;
    public Stack<Rigidbody> balls = new Stack<Rigidbody>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item") && other.GetComponent<Ball>().State == Ball.ballState.READY)
        {
            balls.Push(other.attachedRigidbody);
            other.transform.parent = transform;
            other.gameObject.SetActive(false);
            other.GetComponent<Ball>().State = Ball.ballState.PICKED_UP;

        }
    }

    
}
