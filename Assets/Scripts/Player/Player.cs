using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D _rigidbody2D;
    private bool _isGround;
    [SerializeField] private Actions _actions;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _actions.Run();
    }
    
}
