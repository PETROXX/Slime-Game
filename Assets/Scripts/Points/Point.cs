using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AudioSource))]

public abstract class Point : MonoBehaviour
{
    protected Slime Slime;

    protected AudioSource AudioSource;
    [SerializeField] private AudioClip CollectSound;

    protected bool WasPointCollected;

    protected virtual void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        Slime = FindObjectOfType<Slime>();
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = CollectSound;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Slime>(out _) && !WasPointCollected)
        {
            CollectPoint();
            WasPointCollected = true;
        }
    }

    protected abstract void CollectPoint ();
}
