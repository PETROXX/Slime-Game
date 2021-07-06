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

    public virtual void CollectPoint()
    {
        AudioSource.Play();
        WasPointCollected = true;
    }
}
