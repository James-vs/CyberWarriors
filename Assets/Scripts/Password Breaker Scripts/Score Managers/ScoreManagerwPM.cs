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
        overallScore = GetBricksWeight() + GetDifficultyWeight() + livesWeight + PMBonus();
        score = GetBricksWeight();
        //Debug.Log("Score: " + score);
        UpdateScoreText();
    }

    /// <summary>
    /// function to update the score in the pause menu 
    /// </summary>
    public override void UpdateScoreText () {
        pauseScoreText.text = "" + score;
        baseScoreText.text = "" + score;
        overallScoreText.text = "" + overallScore;
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
