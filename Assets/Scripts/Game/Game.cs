using UnityEngine;

[RequireComponent(typeof(GameLocation))]
[RequireComponent(typeof(GameView))]

public class Game : MonoBehaviour
{
    private float _textCooldown = 5;
    private float _currentTextCooldown;
    private Slime _slime;
    private GameLocation _gameLocation;
    private GameView _gameUI;
    private bool _isCooldownStarted;

    public float CurrentTextCooldown => _currentTextCooldown;
    public bool IsCooldownStarted => _isCooldownStarted;

    private void Start()
    {
        _gameLocation = GetComponent<GameLocation>();
        _slime = FindObjectOfType<Slime>();
        _currentTextCooldown = _textCooldown;
        _gameUI = GetComponent<GameView>();
    }

    public void PlayerDied()
    {
        _isCooldownStarted = true;
        _gameUI.PlayerDied();
    }

    private void Update()
    {
        if (!_slime.IsAlive && !IsCooldownStarted)
            PlayerDied();

        if (_isCooldownStarted)
        {
            _currentTextCooldown -= Time.deltaTime;
            if (_currentTextCooldown <= 0)
            {
                _currentTextCooldown = _textCooldown;
                _isCooldownStarted = false;
                _slime.Respawn();
                _gameLocation.RestartGame();
            }
        }
    }
}