using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverArm : MonoBehaviour
{
    [SerializeField] private bool _isTouch;
    [SerializeField] private GameObject _player;
    [SerializeField] private Animator _animator;
    public float Dist;

    bool isTouch
    {
        get { return _isTouch;}
        set { _isTouch = value; OnActions.Invoke(); }
    }
    [SerializeField]private UnityEvent OnActions = new UnityEvent();

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator.SetBool("isTouch",false);
    }

    private void Update()
    {
        Dist = Vector2.Distance(_player.transform.position, gameObject.transform.position);
        
        if (Input.GetKeyDown(KeyCode.E)&&Dist<=2f)
        {
            isTouch = true;
            _animator.SetBool("isTouch",true);
        }
    }
}
