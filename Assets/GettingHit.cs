using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingHit : MonoBehaviour
{

    public Animator m_Animator;
    public int maxHP;
    private int currHP;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        currHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;
        if (other.CompareTag("Item") && other.GetComponent<Ball>().State == Ball.ballState.THROWN && currHP > 0)
        {
            currHP--;
            if(currHP == 0) { 
                m_Animator.SetTrigger("dead"); 
            }
            else
            {
                m_Animator.SetTrigger("hit");
            }
        }
    }

}
