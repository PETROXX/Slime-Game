using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : Point
{ 
    [SerializeField] private GameObject _collectEffect;

    private bool _wasCollected;

    private void Start()
    {
        Initialize();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Slime>(out Slime _) && !_wasCollected)
        {
            CollectPoint();
        }
    }

    protected override void CollectPoint()
    {
        _wasCollected = true;
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
