using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AudioSource))]

public abstract class Point : MonoBehaviour
{

    [SerializeField] private AudioClip CollectSound;

    protected AudioSource AudioSource;
    protected bool WasPointCollected;

    protected virtual void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = CollectSound;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Slime>(out Slime slime) && !WasPointCollected)
        {
            CollectPoint(slime);
            WasPointCollected = true;
        }
    }

    protected abstract void CollectPoint(Slime slime);
}
