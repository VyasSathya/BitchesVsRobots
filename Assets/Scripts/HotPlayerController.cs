using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPlayerController : MonoBehaviour
{
    public enum playerState { DEFAULT, DEAD, GETTING_HIT, THROW, THROW_END };
    public enum playerMotion { IDLE, WALK, WALK_BACK, LEFT, RIGHT, RUN };
    public playerState state;
    public playerMotion motion;
    public bool isWalking;
    Animator m_Animator;
    public float xMouseSensitivity = 8;
    public float yMouseSensitivity = 0.75f;
    //public bool invertedUpDown; TODO inverted camera
    public float moveSpeed = 1.5f;
    public PlayerInventory m_Inventory;
    public Transform rightHandJoint;
    public Rigidbody currBall;
    public int throwStrength;
    public float yForceOnThrow;
    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
        state = playerState.DEFAULT;
        motion = playerMotion.IDLE;
        m_Animator = GetComponent<Animator>();
        m_Inventory = GetComponent<PlayerInventory>();


    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(0, xMouseSensitivity * Input.GetAxis("Mouse X"), 0);
        camera.Rotate(yMouseSensitivity * Input.GetAxis("Mouse Y"), 0, 0);
        //mouseSensitivity* Input.GetAxis("Mouse Y")

        if (state == playerState.THROW_END && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            state = playerState.DEFAULT;
        }
            
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_Inventory.balls.Count != 0 && state == playerState.DEFAULT ) {
                Debug.Log("Text Throw the Ball");
                state = playerState.THROW;
                m_Animator.SetTrigger("isThrowing");
                currBall = m_Inventory.balls.Pop();
                readyTheBall(currBall);
            }
            
        }
        else if (Input.GetKey(KeyCode.W))
        {
            //isWalking = true;
            motion = playerMotion.WALK;
            transform.position += moveSpeed * transform.forward * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            motion = playerMotion.WALK_BACK;
            transform.position -= moveSpeed * transform.forward * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            motion = playerMotion.LEFT;
            transform.position -= moveSpeed *  transform.right * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            motion = playerMotion.RIGHT;
            transform.position += moveSpeed * transform.right * Time.deltaTime;
        }
        else 
        {
            motion = playerMotion.IDLE;

        }
        m_Animator.SetInteger("motion", (int)motion);


    }

    void readyTheBall(Rigidbody ball)
    {
        ball.gameObject.SetActive(true);
        ball.transform.parent = rightHandJoint;
        ball.transform.localPosition = Vector3.zero;
        ball.isKinematic = true;

    }

    // Called from animation event
    void Throw() {
        state = playerState.THROW_END;
        currBall.isKinematic = false;
        Vector3 tempVect = throwStrength * (transform.forward + new Vector3(0, yForceOnThrow, 0));
        currBall.AddForce(tempVect);
        currBall.transform.parent = null;
        currBall.GetComponent<Ball>()?.resetBall();
        
    }



}