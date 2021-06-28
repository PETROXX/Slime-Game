using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(DragSlime))]

public class SlimeAnimation : MonoBehaviour
{
    private Animator _animator;
    private DragSlime _dragSlime;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _dragSlime = GetComponent<DragSlime>();
    }

    void Update()
    {
        _animator.SetBool("IsJumping", !_dragSlime.IsGrounded);
    }
}
