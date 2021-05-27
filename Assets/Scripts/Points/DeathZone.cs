using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : Point
{
    private void Start()
    {
        Initialize();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Slime>(out _))
        {
            CollectPoint();
        }
    }

    protected override void CollectPoint()
    {
        Slime.Die();
    }
}
