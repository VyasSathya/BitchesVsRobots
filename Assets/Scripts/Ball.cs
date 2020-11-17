using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public enum ballState { READY, PICKED_UP }
    public ballState State;

    // Start is called before the first frame update
    void Start()
    {
        State = ballState.READY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetBall() {
        StartCoroutine(ballStateDelay());

    }

    IEnumerator ballStateDelay()
    {
        yield return new WaitForSeconds(3);
        State = Ball.ballState.READY;

    }
}
