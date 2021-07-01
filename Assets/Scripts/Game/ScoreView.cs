using TMPro;
using UnityEngine;


public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private Slime _slime;

    private void Start()
    {
        _slime = FindObjectOfType<Slime>();
    }

    private void Update()
    {
        _scoreText.text = $"Score: {_slime.Score}";
    }
}
