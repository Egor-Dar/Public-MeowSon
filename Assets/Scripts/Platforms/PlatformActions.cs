using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActions : MonoBehaviour
{
    public float translation;
    
    public void Run()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + translation, gameObject.transform.position.y);
    }

    public void Active()
    {
        gameObject.SetActive(false);
    }
}
