using System;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Actionss : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private bool _isGround;
    [SerializeField] private float _speed;
    float locationX;
    float locationY;
    public SpriteRenderer Renderer;
    [SerializeField]private Vector2 location;
    [SerializeField]private Vector2 targetRay;

    private void Start()
    {
        targetRay = new Vector2(0, 0);
    }


    public void Run()
    {
        Vector2 playerRay;

        if (Input.GetKeyDown(KeyCode.W))
            {
                playerRay = new Vector3(transform.position.x, transform.position.y + 5f);
                    
                RaycastHit2D hit = Physics2D.Raycast(playerRay, transform.up);
                targetRay = hit.collider.gameObject.transform.position;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                locationX = 0;
                locationY = -1;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                locationX = -1;
                locationY = 0;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                locationX = 1;
                locationY = 0;
            }

            if (locationX != 0)
                locationY = 0;
            if (locationY != 0)
                locationX = 0;

            location = Vector2.Lerp(transform.position, targetRay, 0.1f);
            transform.position = location;
    }

   // private void OnTriggerEnter2D(Collider2D other)
   // {
   //     Debug.Log(other.gameObject.name);
   //     if (other.gameObject.name==_RayTouchPlatform)
   //     {
   //         Debug.Log("Lol");
   //         _isGround = true;
   //         _player._rigidbody2D.velocity = Vector2.zero;
   //         locationX = 0;
   //         locationY = 0;
   //     }
   //     else
   //     {
   //         _isGround = false;
   //     }
   // }

}