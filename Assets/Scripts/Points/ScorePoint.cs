using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : Point
{ 
    [SerializeField] private GameObject _collectEffect;


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
        Slime.AddPoint();
        gameObject.SetActive(false);
        _collectEffect.SetActive(true);
        gameObject.SetActive(true);
        StartCoroutine(DestroyPoint());
        AudioSource.Play();
    }

    IEnumerator DestroyPoint()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
