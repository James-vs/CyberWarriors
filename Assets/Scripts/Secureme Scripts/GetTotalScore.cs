using UnityEngine;
using TMPro;
using System;

public class GetTotalScore : MonoBehaviour
{
    [Header("Score Keys")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI totalScoreText;
    [SerializeField] private string tutorialScoreKey;
    [SerializeField] private string l1ScoreKey;
    [SerializeField] private string l2ScoreKey;
    [SerializeField] private string l3ScoreKey;
    [SerializeField] private string l4ScoreKey;
    [SerializeField] private string TotalScoreKey = "SMTotalHighscore";

    [Header("Session controller")]
    [SerializeField] private GameObject sessionController;
    private string[] allScoresKeys;
    public bool hasTextFields = true;

    // Start is called before the first frame update
    void Start()
    {
        // create a list of all game allScores
        allScoresKeys = new string[]{tutorialScoreKey,l1ScoreKey,l2ScoreKey,l3ScoreKey,l4ScoreKey};
        // assign the score values to the text fields to display them
        if (hasTextFields)
        {
            scoreText.text = PlayerPrefs.GetFloat(l4ScoreKey).ToString("0") + " POINTS";
            totalScoreText.text = TotalScore().ToString("0") + " POINTS";
        }
    }

    public float TotalScore() {
        float total = 0f;
        foreach (string scoreKey in allScoresKeys)
        {
            total += PlayerPrefs.GetFloat(scoreKey);
        }

        Debug.Log("(From GetTotalScore) Total Score: " + total); //added for debugging

        int totalScore = PlayerPrefs.GetInt(TotalScoreKey);

        if (totalScore <= Convert.ToInt32(total))
        {
            PlayerPrefs.SetInt(TotalScoreKey, Convert.ToInt32(total));
            //sessionController.GetComponent<SessionController>().UploadScore();
            return total;
        }
        else
        {
            //sessionController.GetComponent<SessionController>().UploadScore();
            return totalScore;
        }
        
    }
}
