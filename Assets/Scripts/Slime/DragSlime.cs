using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Slime))]

public class DragSlime : MonoBehaviour
{
    [SerializeField] private float _force;

    private bool _isGrounded;

    private Rigidbody2D _rigidbody;

    private Vector2 _startPoint;
    private Vector2 _endPoint;

    public bool IsGrounded => _isGrounded;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rigidbody.velocity.x > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else
            transform.eulerAngles = new Vector3(0, 180, 0);


        if (Input.GetMouseButtonDown(0))
        {
            _startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);  
        }

        if(Input.GetMouseButtonUp(0))
        {
            _endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 force = (_endPoint - _startPoint).normalized * Vector2.Distance(_startPoint, _endPoint) * _force;
            _rigidbody.AddForce(force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Ground>(out _))
        {
            _isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out _))
        {
            _isGrounded = false;
        }
    }
}