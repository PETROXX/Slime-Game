using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(GameLocation))]

public class Game : MonoBehaviour
{
    [SerializeField] private TMP_Text _gameOverText;
    private float _textCooldown = 5;

    private Slime _slime;
    private GameLocation _gameLocation;
    private bool _isCooldownStarted;

    private void Start()
    {
        _gameLocation = GetComponent<GameLocation>();
        _slime = FindObjectOfType<Slime>();
    }

    public void PlayerDied()
    {
        _gameOverText.text = $"Game over! Restart in {_textCooldown} seconds";
        _gameOverText.gameObject.SetActive(true);
        _isCooldownStarted = true;
    }

    private void Update()
    {
        if (!_slime.IsAlive)
            PlayerDied();
        if(_isCooldownStarted)
        {
            _textCooldown -= Time.deltaTime;
            _gameOverText.text = $"Game over! Restart in {(int)_textCooldown} seconds";
            if(_textCooldown <= 0)
            {
                _textCooldown = 5;
                _isCooldownStarted = false;
                _gameOverText.gameObject.SetActive(false);
                _slime.Respawn();
                _gameLocation.RestartGame();
            }
        }
    }
}
