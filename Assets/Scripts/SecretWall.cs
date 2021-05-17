using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWall : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.layer==7)
        {
            gameObject.layer = 9;
            gameObject.GetComponent<PlatformEffector2D>().enabled = false;
        }
    }
}
