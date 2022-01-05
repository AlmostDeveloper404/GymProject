using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private Text _text;
    private int _startScore;

    private void Start()
    {
        UpdateScore(_startScore);
    }
    public void UpdateScore(int score)
    {
        _startScore += score;
        _text.text = _startScore.ToString();
    }
}
