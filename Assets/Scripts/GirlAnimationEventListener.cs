using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlAnimationEventListener : MonoBehaviour
{
    public HotPlayerController hotPlayerController;
    void Throw() {
        hotPlayerController.ActivateThrow();
    }
}
