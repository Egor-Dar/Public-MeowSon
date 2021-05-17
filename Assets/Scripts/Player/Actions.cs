using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Actions : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private bool _isGround;
    Vector2 location;
    public SpriteRenderer Renderer;
    private string _RayTouchPlatform;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private CircleCollider2D CircleCollider;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        
        Vector3 playerRay = new Vector3(transform.position.x, transform.position.y - 5f,transform.position.z);
        RaycastHit2D hit = Physics2D.Raycast(playerRay, -transform.up, _mask);
        _RayTouchPlatform = hit.collider.gameObject.name;
        Debug.Log("Я попал в "+ _RayTouchPlatform);
    }

    public void Run()
    {
        _animator.SetBool("IsGround",_isGround);
        if (_isGround)
        {
            
            Vector3 playerRay;
            
                     if (Input.GetKeyDown(KeyCode.W))
                     {
                         playerRay = new Vector3(transform.position.x, transform.position.y + 5f,transform.position.z);
                         RaycastHit2D hit = Physics2D.Raycast(playerRay, transform.up,Mathf.Infinity,_mask);
                         if (Physics2D.Raycast(transform.position, transform.up,Mathf.Infinity, _mask))
                         {
                             _RayTouchPlatform = hit.collider.gameObject.name;
                         }

                             _animator.SetBool("Up",true);
                             StartCoroutine(TimerUp());
                         location.y = 3;
                             _isGround = false;
                     }   

                     if (Input.GetKeyDown(KeyCode.S))
                    {
                        playerRay = new Vector3(transform.position.x, transform.position.y - 5f,transform.position.z);
                        RaycastHit2D hit = Physics2D.Raycast(playerRay, -transform.up,Mathf.Infinity,_mask);
                        if (Physics2D.Raycast(playerRay, -transform.up,Mathf.Infinity,_mask))
                        {
                            _RayTouchPlatform = hit.collider.gameObject.name;
                            Debug.Log("Я попал в "+ _RayTouchPlatform);
                        }                        _animator.SetBool("Down",true);
                        StartCoroutine(TimerDown());
                        location.y = -3;
                        _isGround = false;
                    }

                     if (Input.GetKeyDown(KeyCode.A))
                    {
                        playerRay = new Vector3(transform.position.x-5f, transform.position.y ,transform.position.z);
                        RaycastHit2D hit = Physics2D.Raycast(playerRay, -transform.right,Mathf.Infinity,_mask);
                        if (Physics2D.Raycast(playerRay, -transform.right,Mathf.Infinity,_mask))
                        {
                            _RayTouchPlatform = hit.collider.gameObject.name;
                            Debug.Log("Я попал в "+ _RayTouchPlatform);
                        }
                        _RayTouchPlatform = hit.collider.gameObject.name;
                        _animator.SetBool("Horizontal",true);
                        StartCoroutine(TimerHorizontal());

                        Renderer.flipX = true;
                        location.x = -3;
                        _isGround = false;
                    }

                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        playerRay = new Vector3(transform.position.x+ 5f, transform.position.y ,transform.position.z);
                        RaycastHit2D hit = Physics2D.Raycast(playerRay, transform.right,Mathf.Infinity,_mask);
                        if (Physics2D.Raycast(transform.position, transform.right,Mathf.Infinity, _mask))
                        {
                            _RayTouchPlatform = hit.collider.gameObject.name;
                            Debug.Log("Я попал в "+ _RayTouchPlatform);
                        }
                        _animator.SetBool("Horizontal",true);
                        StartCoroutine(TimerHorizontal());

                        Renderer.flipX = false;
                        location.x = 3;
                        _isGround = false;
                    }
                    

                    
                    CircleCollider.enabled=false;
                    Physics2D.gravity = location;
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name==_RayTouchPlatform)
        {
            Debug.Log("Lol");
            _isGround = true;
            _player._rigidbody2D.velocity = Vector2.zero;
            location.x = 0;
            location.y = 0;
        }

        if (other.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator TimerUp()
    {
        yield return new WaitForSeconds(0.2f);
        _animator.SetBool("Up",false);
        CircleCollider.enabled=true;

    }

    IEnumerator TimerDown()
    {
        yield return new WaitForSeconds(0.2f);
        _animator.SetBool("Down",false);
        CircleCollider.enabled=true;

    }

    IEnumerator TimerHorizontal()
    {

        yield return new WaitForSeconds(0.2f);
        _animator.SetBool("Horizontal",false);
        CircleCollider.enabled=true;
    }

}