using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirnsTouch : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        gameObject.layer=0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        _animator.SetBool("Touch",true);
        gameObject.layer = 10;
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool("Touch",false);
        gameObject.layer = 0;
    }
}
