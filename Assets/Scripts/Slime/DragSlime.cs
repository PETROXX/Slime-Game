using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Slime))]

public class DragSlime : MonoBehaviour
{
    [SerializeField] private float _force;

    [SerializeField] private Transform _groundCheck;

    private bool _isGrounded;

    private Rigidbody2D _rig;

    private Vector2 _startPoint;
    private Vector2 _endPoint;

    public bool IsGrounded => _isGrounded;

    private void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       // _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.05f);

        if (_rig.velocity.x > 0)
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
            _rig.AddForce(force);
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