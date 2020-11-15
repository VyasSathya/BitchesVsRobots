using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPlayerController : MonoBehaviour
{

    public bool isWalking;
    Animator m_Animator;
    public float mouseSensitivity = 8;
    public float moveSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
        m_Animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {


        transform.Rotate(0, mouseSensitivity * Input.GetAxis("Mouse X"), 0);
        if (Input.GetKey(KeyCode.W))
        {
            isWalking = true;
            transform.position += moveSpeed * transform.forward * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            isWalking = true;
            transform.position -= moveSpeed * transform.forward * Time.deltaTime;
        }
        else
        {
            isWalking = false;
            
        }
        m_Animator.SetBool("isWalking", isWalking);


    }





}
