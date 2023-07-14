using UnityEngine;
using TMPro;

public class ScoreManagerwPM : ScoreManager
{
    [SerializeField] protected TextMeshProUGUI PMBonusText;
    protected int PMCount = 0;

    protected int PMBonus() {
        return PMCount * 1000;
    }
    
    /// <summary>
    /// function to calculate the score (int)
    /// </summary>
    protected override void CalculateScore() {
        GetLivesWeight();
        overallScore = GetBaseScore() + GetDifficultyWeight() + livesWeight + PMBonus();
        //Debug.Log("Score: " + score);
        UpdateScoreText();
    }

    /// <summary>
    /// function to update the score in the pause menu 
    /// </summary>
    public override void UpdateScoreText () {
        pauseScoreText.text = "" + score;
        baseScoreText.text = "" + score;
        gameUIScoreText.text = "Score: " + score;
        overallScoreText.text = "" + overallScore;
        multiplierText.text = "x" + multiplier;
        difficultyBonusText.text = "" + GetDifficultyWeight();
        livesBonusText.text = "" + livesWeight;
        PMBonusText.text = "" + PMBonus();
    }


    /// <summary>
    /// function to update the PM destroyed count
    /// </summary>
    public void UpdatePMBonus() {
        PMCount += 1;
    }
}
