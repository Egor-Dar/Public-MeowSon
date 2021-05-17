using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirnsTouch : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        this.gameObject.layer=0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Timer());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("Touch",false);
            gameObject.layer = 0;
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
        _animator.SetBool("Touch",true);
        gameObject.layer = 10;
    }
}
