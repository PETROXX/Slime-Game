using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Slime))]

public class DragSlime : MonoBehaviour
{
    [SerializeField] private float _force;

    [SerializeField] private Transform _groundCheck;

    private bool _isGrounded;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rig;

    private float _startSize;

    private Vector2 _startPoint;
    private Vector2 _endPoint;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rig = GetComponent<Rigidbody2D>();

        _startSize = transform.position.x;
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.05f);
        _animator.SetBool("IsJumping", !_isGrounded);

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
}