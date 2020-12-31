using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPlayer : MonoBehaviour
{
    public int avatarType = 0;
    public List<Transform> avatarTransforms = new List<Transform>();
    HotPlayerController hotPlayerController;


    // Start is called before the first frame update
    void Start()
    {
        hotPlayerController = GetComponent<HotPlayerController>();
        foreach(Transform t in avatarTransforms)
        {
            t.gameObject.SetActive(false);
        }
        if (avatarTransforms[avatarType] != null)
        {
            avatarTransforms[avatarType].gameObject.SetActive(true);
            hotPlayerController.m_Animator = avatarTransforms[avatarType].GetComponent<Animator>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
