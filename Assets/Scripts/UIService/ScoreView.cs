
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoretext;
    private int score;
    private void Start()
    {
        scoretext.enabled = true;
        scoretext.text = "00";
        score = 0;
    }

    public TextMeshProUGUI GetScoreText() => scoretext;
}
