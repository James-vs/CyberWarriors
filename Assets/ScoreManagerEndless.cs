using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerEndless : ScoreManagerwPM
{
    [SerializeField] private bool pMExists = false;
    [SerializeField] private string playerPrefsVariable;

    /// <summary>
    /// function to override the 'grandparent' class function UpdateScoreText()
    /// </summary>
    public override void UpdateScoreText()
    {
        if (pMExists)
        {
            pauseScoreText.text = "" + score;
            baseScoreText.text = "" + score;
            gameUIScoreText.text = "Score: " + score;
            overallScoreText.text = "" + overallScore;
            PlayerPrefs.SetInt(playerPrefsVariable, overallScore);
            multiplierText.text = "x" + multiplier;
            difficultyBonusText.text = "" + GetDifficultyWeight();
            livesBonusText.text = "" + livesWeight;
            PMBonusText.text = "" + PMBonus();
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
}
