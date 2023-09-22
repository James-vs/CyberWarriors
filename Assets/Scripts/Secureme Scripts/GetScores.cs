using UnityEngine;
using TMPro;

public class GetScores : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private string scoreKey;
    [SerializeField] private string highScoreKey;

    // Start is called before the first frame update
    void Start()
    {
        // assign the score values to the text fields to display them
        scoreText.text = PlayerPrefs.GetFloat(scoreKey).ToString("0") + " POINTS";
        highScoreText.text = PlayerPrefs.GetFloat(highScoreKey).ToString("0") + " POINTS";
    }
}
