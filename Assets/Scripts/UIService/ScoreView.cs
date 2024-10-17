
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoretext;
    private void Start()
    {
        scoretext.enabled = true;
        scoretext.text = "00";
    }

    public TextMeshProUGUI GetScoreText() => scoretext;
}
