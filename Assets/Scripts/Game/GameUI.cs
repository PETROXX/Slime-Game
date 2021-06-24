using UnityEngine;
using TMPro;

[RequireComponent(typeof(Game))]

public class GameUI : MonoBehaviour
{
    private Game _game;
    private Slime _slime;

    [SerializeField] private TMP_Text _gameOverText;
    [SerializeField] private TMP_Text _scoreText;

    private void Start()
    {
        _game = GetComponent<Game>();
        _slime = FindObjectOfType<Slime>();
    }

    private void Update()
    {
        if (_game.IsCooldownStarted)
            _gameOverText.text = $"Game over! Restart in {(int)_game.CurrentTextCooldown} seconds";
        else
            _gameOverText.gameObject.SetActive(false);

        _scoreText.text = $"Score: {_slime.Score}";
    }

    public void PlayerDied()
    {
        _gameOverText.text = $"Game over! Restart in {_game.CurrentTextCooldown} seconds";
        _gameOverText.gameObject.SetActive(true);
    }
}
