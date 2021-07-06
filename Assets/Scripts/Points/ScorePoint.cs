using System.Collections;
using UnityEngine;

public class ScorePoint : Point
{
    [SerializeField] private GameObject _collectEffect;

    private float _effectLenght = 0.5f;

    protected override void Start()
    {
        base.Start();
    }

    public override void CollectPoint()
    {
        if (WasPointCollected)
            return;

        base.CollectPoint();
        gameObject.SetActive(false);
        _collectEffect.SetActive(true);
        gameObject.SetActive(true);
        StartCoroutine(DestroyPoint());
    }

    private IEnumerator DestroyPoint()
    {
        yield return new WaitForSeconds(_effectLenght);
        Destroy(gameObject);
    }
}
