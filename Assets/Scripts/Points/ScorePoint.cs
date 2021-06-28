using System.Collections;
using UnityEngine;

public class ScorePoint : Point
{
    [SerializeField] private GameObject _collectEffect;

    private float _effectLenght = 0.05f;

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    protected override void CollectPoint(Slime slime)
    {
        slime.AddPoint();
        gameObject.SetActive(false);
        _collectEffect.SetActive(true);
        gameObject.SetActive(true);
        StartCoroutine(DestroyPoint());
        AudioSource.Play();
    }

    IEnumerator DestroyPoint()
    {
        yield return new WaitForSeconds(_effectLenght);
        Destroy(gameObject);
    }
}
