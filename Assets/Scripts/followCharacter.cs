using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCharacter : MonoBehaviour
{
    public Transform characterTransform;
    public Vector3 offsetVect = new Vector3(0,5,-3);
    public float theta = 0;
    public float zDirect = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 personPos = characterTransform.position;
        Vector3 personForward = characterTransform.forward;
        Vector3 personRot = characterTransform.eulerAngles;
        theta = personRot.y;
        zDirect = Mathf.Cos(personRot.y * Mathf.PI / 180.0f);

        //offsetVect = new Vector3(-3 * Mathf.Sin((personRot.y * Mathf.PI / 180.0f)), 2, -3 * Mathf.Cos(personRot.y * Mathf.PI / 180.0f));
        //offsetVect = new Vector3(0,2,0);
        offsetVect = -3 * personForward + new Vector3(0,2,0);


        transform.eulerAngles = personRot;
        transform.position = personPos + offsetVect;
        
    }
}
