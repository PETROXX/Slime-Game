using TMPro;
using UnityEngine;

[RequireComponent(typeof(Game))]

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _gameOverText;

    private Game _game;

    private void Start()
    {
        _game = GetComponent<Game>();
    }

    private void Update()
    {
        if (_game.IsCooldownStarted)
            _gameOverText.text = $"Game over! Restart in {(int)_game.CurrentTextCooldown} seconds";
        else
            _gameOverText.gameObject.SetActive(false);

    }

    public void PlayerDied()
    {
        _gameOverText.text = $"Game over! Restart in {_game.CurrentTextCooldown} seconds";
        _gameOverText.gameObject.SetActive(true);
    }
}
