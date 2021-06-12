using TMPro;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(DragSlime))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]

public class Slime : MonoBehaviour
{
    [SerializeField] private float _score;

    [SerializeField] private TMP_Text _scoreText;

    [SerializeField] private GameObject _dieEffect;

    [SerializeField] private Vector2 _spawnPosition;

    private DragSlime _dragSlime;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rig;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _deathSound;

    public bool IsAlive { get; private set; }

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

    private void Update()
    {
        _scoreText.text = $"Score: {_score}";
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
        yield return new WaitForSeconds(2);
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
