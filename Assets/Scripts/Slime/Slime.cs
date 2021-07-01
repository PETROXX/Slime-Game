using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(DragSlime))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]

public class Slime : MonoBehaviour
{
    [SerializeField] private float _score;
    [SerializeField] private GameObject _dieEffect;
    [SerializeField] private Vector2 _spawnPosition;
    [SerializeField] private AudioClip _deathSound;

    private DragSlime _dragSlime;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private AudioSource _audioSource;
    private float _deathEffectLenght = 2f;

    public float Score => _score;
    public bool IsAlive { get; private set; }


    private void Start()
    {
        IsAlive = true;
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _dragSlime = GetComponent<DragSlime>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _deathSound;
        _rigidbody.position = _spawnPosition;
    }

    public void AddPoint()
    {
        _score++;
    }

    public void Die()
    {
        _audioSource.Play();
        _spriteRenderer.enabled = false;
        _dragSlime.enabled = false;
        _dieEffect.SetActive(true);
        _rigidbody.bodyType = RigidbodyType2D.Static;
        StartCoroutine(DestroySlime());
        IsAlive = false;
    }

    private IEnumerator DestroySlime()
    {
        yield return new WaitForSeconds(_deathEffectLenght);
        gameObject.SetActive(false);
    }

    public void Respawn()
    {
        _dieEffect.SetActive(false);
        IsAlive = true;
        _spriteRenderer.enabled = true;
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _dragSlime.enabled = true;
        _rigidbody.position = _spawnPosition;
        _score = 0;
        gameObject.SetActive(true);
    }
}