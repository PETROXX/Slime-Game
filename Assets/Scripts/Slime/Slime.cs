using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(DragSlime))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]

public class Slime : MonoBehaviour
{
    [SerializeField] private float _score;

    public float Score => _score;

    [SerializeField] private GameObject _dieEffect;

    [SerializeField] private Vector2 _spawnPosition;

    private DragSlime _dragSlime;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rig;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _deathSound;

    public bool IsAlive { get; private set; }

    private float _deathEffectLenght = 2f;

    private void Start()
    {
        IsAlive = true;
        _rig = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _dragSlime = GetComponent<DragSlime>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _deathSound;
        _rig.position = _spawnPosition;
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
        _rig.bodyType = RigidbodyType2D.Static;
        StartCoroutine(DestroySlime());
        IsAlive = false;
    }

    IEnumerator DestroySlime()
    {
        yield return new WaitForSeconds(_deathEffectLenght);
        gameObject.SetActive(false);
    }

    public void Respawn()
    {
        _dieEffect.SetActive(false);
        IsAlive = true;
        _spriteRenderer.enabled = true;
        _rig.bodyType = RigidbodyType2D.Dynamic;
        _dragSlime.enabled = true;
        _rig.position = _spawnPosition;
        _score = 0;
        gameObject.SetActive(true);
    }
}