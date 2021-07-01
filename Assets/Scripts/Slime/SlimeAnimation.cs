using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(DragSlime))]

public class SlimeAnimation : MonoBehaviour
{
    private Animator _animator;
    private DragSlime _dragSlime;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _dragSlime = GetComponent<DragSlime>();
    }

    private void Update()
    {
        _animator.SetBool("IsJumping", !_dragSlime.IsGrounded);
    }
}
