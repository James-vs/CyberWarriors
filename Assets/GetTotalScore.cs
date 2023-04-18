using UnityEngine;
using TMPro;

public class GetTotalScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI totalScoreText;
    [SerializeField] private string tutorialScoreKey;
    [SerializeField] private string l1ScoreKey;
    [SerializeField] private string l2ScoreKey;
    [SerializeField] private string l3ScoreKey;
    [SerializeField] private string l4ScoreKey;
    private string[] allScoresKeys;

    // Start is called before the first frame update
    void Start()
    {
        // create a list of all game allScores
        allScoresKeys = new string[]{tutorialScoreKey,l1ScoreKey,l2ScoreKey,l3ScoreKey,l4ScoreKey};
        // assign the score values to the text fields to display them
        scoreText.text = PlayerPrefs.GetFloat(l4ScoreKey).ToString("0") + " POINTS";
        totalScoreText.text = TotalScore().ToString("0") + " POINTS";
    }

    protected float TotalScore() {
        float total = 0f;
        foreach (string scoreKey in allScoresKeys)
        {
            total += PlayerPrefs.GetFloat(scoreKey);
        }
        return total;
    }
}
