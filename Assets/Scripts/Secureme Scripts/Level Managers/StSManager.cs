using UnityEngine;
using TMPro;
using System;

public class StSManager : MonoBehaviour
{
    //class to be inherited for game level scripts

    [SerializeField] protected GameObject success;
    [SerializeField] protected GameObject fail;
    [SerializeField] protected LoadNextScene loadNextScene;
    [SerializeField] protected bool gameOver = false;
    protected int matches = 0;
    [SerializeField] protected TextMeshProUGUI matchesUI;
    [SerializeField] protected Timer timer;
    [SerializeField] protected bool outOfTime = false;
    [SerializeField] protected string scoreKey;
    [SerializeField] protected string highScoreKey;
    [SerializeField] protected string browserProgression = "SMBProgression";
    [SerializeField] protected string sMTotalHighscore = "SMTotalHighscore";
    [SerializeField] protected GetTotalScore getTotalScore;
    [SerializeField] protected GameObject sessionController;


    //function to end the game if the timer runs out
    public void OutOfTime (bool value) {
        Debug.Log("OutOfTime called");
        gameOver = value;
        outOfTime = value;
    }

    //function to handle logic for matching and selecting of buttons
    public float Match(bool firstMatch, bool pair1, bool match1) {
        if (!firstMatch && !outOfTime) {
            if (!pair1 && !match1) {
                return 1; //if button selected
            } else {
                return 2; //if button deselected
            }
        }
        return 3; //do nothing
    }


    // #### FUNCTIONS TO HANDLE NoSQL DATABASE QUERIES

    // function to save the score + append the highscore
    protected void SaveScore(string scoreKey, string highScoreKey, int matches){
        float initialTotalHighScore = 0;
        if (PlayerPrefs.HasKey(sMTotalHighscore)) initialTotalHighScore = PlayerPrefs.GetInt(sMTotalHighscore);

        float score = matches * (1000 + (timer.GetValue() * 10));
        PlayerPrefs.SetFloat(scoreKey,score);

        if (PlayerPrefs.HasKey(highScoreKey))
        {
            var originalHighscore = PlayerPrefs.GetFloat(highScoreKey);

            if (originalHighscore < score) {
                PlayerPrefs.SetFloat(highScoreKey,score);
                PlayerPrefs.SetInt(sMTotalHighscore, Convert.ToInt32(initialTotalHighScore + (score - originalHighscore)));
                
            }
        }
        else
        {
            PlayerPrefs.SetFloat(highScoreKey, score);
            PlayerPrefs.SetInt(sMTotalHighscore, Convert.ToInt32(initialTotalHighScore + score));
        }
        Debug.Log("Total high score: " + getTotalScore.TotalScore().ToString("0"));
        sessionController.GetComponent<SessionController>().UploadScore();

    }

    // function to check if a highscore PlayerPrefs key exists, creates one if not
    protected void CheckForHighscore(string highScoreKey) {
        if (!PlayerPrefs.HasKey(highScoreKey)) {
            PlayerPrefs.SetFloat(highScoreKey,0f);
        }
    }

    // function to reset the saved score
    protected void ResetScore() {
        PlayerPrefs.SetFloat(scoreKey,0f);
    }
}
