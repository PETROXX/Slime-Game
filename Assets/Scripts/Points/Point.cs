using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AudioSource))]

public abstract class Point : MonoBehaviour
{
    protected Slime Slime;

    protected AudioSource AudioSource;
    [SerializeField] private AudioClip CollectSound;

    protected virtual void Initialize()
    {
        Slime = FindObjectOfType<Slime>();
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = CollectSound;
    }

    protected abstract void CollectPoint ();
}
