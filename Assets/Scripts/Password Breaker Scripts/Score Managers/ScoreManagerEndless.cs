using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagerEndless : ScoreManagerwPM
{
    [Header("Game Over Text Objects")]
    [SerializeField] protected TextMeshProUGUI endBaseScoreText;
    [SerializeField] protected TextMeshProUGUI endDifficultyBonusText;
    [SerializeField] protected TextMeshProUGUI endLivesBonusText;
    [SerializeField] protected TextMeshProUGUI endOverallScoreText;
    [SerializeField] protected TextMeshProUGUI endPMBonusText;
    [Header("Additional Score Variables")]
    [SerializeField] private bool pMExists = false;
    [SerializeField] private string playerPrefsVariable;

    /// <summary>
    /// function to override the 'grandparent' class function UpdateScoreText()
    /// </summary>
    public override void UpdateScoreText()
    {
        int difficultyWeight = GetDifficultyWeight();
        int pMBonus = PMBonus();
        if (pMExists)
        {
            pauseScoreText.text = "" + score;
            baseScoreText.text = "" + score;
            gameUIScoreText.text = "Score: " + score;
            overallScoreText.text = "" + overallScore;
            PlayerPrefs.SetInt(playerPrefsVariable, overallScore);
            multiplierText.text = "x" + multiplier;
            difficultyBonusText.text = "" + difficultyWeight;
            livesBonusText.text = "" + livesWeight;
            PMBonusText.text = "" + pMBonus;
            endBaseScoreText.text = "" + score;
            endDifficultyBonusText.text = "" + difficultyWeight;
            endLivesBonusText.text = "" + livesWeight;
            endOverallScoreText.text = "" + overallScore;
            endPMBonusText.text = "" + pMBonus;
        }
        else
        {
            pauseScoreText.text = "" + score;
            baseScoreText.text = "" + score;
            gameUIScoreText.text = "Score: " + score;
            overallScoreText.text = "" + overallScore;
            PlayerPrefs.SetInt(playerPrefsVariable, overallScore);
            multiplierText.text = "x" + multiplier;
            difficultyBonusText.text = "" + GetDifficultyWeight();
            livesBonusText.text = "" + livesWeight;
            endBaseScoreText.text = "" + score;
            endDifficultyBonusText.text = "" + difficultyWeight;
            endLivesBonusText.text = "" + livesWeight;
            endOverallScoreText.text = "" + overallScore;
        }
    }
    
    /// <summary>
    /// function to change the value of pMExists bool from another script
    /// </summary>
    /// <param name="value">boolean value</param>
    public void PMExists(bool value)
    {
        this.pMExists = value;
    }

    public override void SetHighScore()
    {
        pBHighScoreString = "PBHighScoreLevelEndless";
        //base.SetHighScore();
        // do i need this override? no?
        /*if (PlayerPrefs.HasKey(pBHighScoreString))
        {
            if (overallScore > PlayerPrefs.GetInt(pBHighScoreString)) PlayerPrefs.SetInt(pBHighScoreString, overallScore);
            Debug.Log("New Highscore: " + overallScore);
        }
        else
        {
            Debug.Log("New Highscore: " + overallScore);
            PlayerPrefs.SetInt(pBHighScoreString, overallScore);
        }*/

        if (PlayerPrefs.HasKey(pBHighScoreString))
        {
            var levelHighScore = PlayerPrefs.GetInt(pBHighScoreString);
            if (overallScore > levelHighScore)
            {
                var initialTHighscore = PlayerPrefs.GetInt(pBTotalHighscore);
                PlayerPrefs.SetInt(pBTotalHighscore, initialTHighscore + (overallScore - levelHighScore));
                PlayerPrefs.SetInt(pBHighScoreString, overallScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt(pBTotalHighscore, PlayerPrefs.GetInt(pBTotalHighscore) + overallScore);
            PlayerPrefs.SetInt(pBHighScoreString, overallScore);
        }
        sessionController.GetComponent<SessionController>().UploadScore();
    }
}
