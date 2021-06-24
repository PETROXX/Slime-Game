using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : Point
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    protected override void CollectPoint()
    {
        Slime.Die();
    }
}
